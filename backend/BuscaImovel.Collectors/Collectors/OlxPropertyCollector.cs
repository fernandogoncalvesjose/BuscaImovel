using BuscaImovel.Collectors.Models;
using HtmlAgilityPack;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BuscaImovel.Collectors.Collectors;

public class OlxPropertyCollector : IPropertyCollector
{
    private readonly HttpClient _http;
    private readonly ILogger<OlxPropertyCollector> _logger;
    private readonly CollectorSettings _settings;

    public OlxPropertyCollector(HttpClient http, IOptions<CollectorSettings> options, ILogger<OlxPropertyCollector> logger)
    {
        _http = http;
        _logger = logger;
        _settings = options.Value;
        // Add conservative extra headers to mimic a browser for testing (still polite)
        try
        {
            _http.DefaultRequestHeaders.Accept.Clear();
            _http.DefaultRequestHeaders.Accept.ParseAdd("text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
            _http.DefaultRequestHeaders.AcceptLanguage.ParseAdd("pt-BR,pt;q=0.9,en-US;q=0.8,en;q=0.7");
            if (!string.IsNullOrWhiteSpace(_settings.BaseUrl))
            {
                // set a sensible referer for requests
                if (Uri.TryCreate(_settings.BaseUrl, UriKind.Absolute, out var baseUri))
                {
                    _http.DefaultRequestHeaders.Referrer = baseUri;
                }
            }
        }
        catch
        {
            // ignore header setup failures
        }
    }

    public async Task<IEnumerable<ExternalPropertyDto>> CollectAsync()
    {
        var results = new List<ExternalPropertyDto>();

        if (!_settings.Enabled)
        {
            _logger.LogInformation("OLX collector is disabled in configuration.");
            return results;
        }

        _logger.LogInformation("Starting OLX collection: {Url}", _settings.SearchUrl);

        for (var page = 1; page <= Math.Max(1, _settings.MaxPages); page++)
        {
            var url = _settings.SearchUrl;
            if (page > 1)
            {
                // OLX uses query params for pagination in some layouts; attempt common patterns
                url = url.Contains('?') ? url + "&page=" + page : url + "?page=" + page;
            }

            try
            {
                _logger.LogInformation("Fetching page {Page}: {Url}", page, url);
                string html;

                // Support local HTML files for offline parsing/testing: file://C:/path/to/file.html
                if (url.StartsWith("file://", StringComparison.OrdinalIgnoreCase))
                {
                    try
                    {
                        var path = url.Substring("file://".Length).Replace('/', Path.DirectorySeparatorChar);
                        html = await File.ReadAllTextAsync(path);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogWarning(ex, "Failed to read local file {Url}", url);
                        continue;
                    }
                }
                else
                {
                    var request = new HttpRequestMessage(HttpMethod.Get, url);
                    // per-request headers
                    request.Headers.Accept.ParseAdd("text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
                    request.Headers.AcceptLanguage.ParseAdd("pt-BR,pt;q=0.9,en-US;q=0.8,en;q=0.7");
                    if (!string.IsNullOrWhiteSpace(_settings.BaseUrl) && Uri.TryCreate(_settings.BaseUrl, UriKind.Absolute, out var b))
                        request.Headers.Referrer = b;

                    using var res = await _http.SendAsync(request);
                    if (!res.IsSuccessStatusCode)
                    {
                        _logger.LogWarning("Failed to fetch {Url}: {Status}", url, res.StatusCode);
                        if (res.StatusCode == System.Net.HttpStatusCode.Forbidden)
                        {
                            _logger.LogWarning("Remote site responded with 403. This is common when sites block automated requests. For testing, you can: (1) save the page HTML locally and set SearchUrl to a file:// path, (2) copy real browser request headers into the HttpClient for local tests, or (3) use official APIs if available.");
                        }
                        continue;
                    }

                    html = await res.Content.ReadAsStringAsync();
                }
                var doc = new HtmlDocument();
                doc.LoadHtml(html);

                var cards = FindListingNodes(doc);
                _logger.LogInformation("Found {Count} listing nodes on page {Page}", cards.Count, page);

                foreach (var node in cards)
                {
                    try
                    {
                        var sourceUrl = ExtractSourceUrl(node);
                        if (string.IsNullOrWhiteSpace(sourceUrl))
                        {
                            _logger.LogDebug("Skipping card without source URL");
                            continue;
                        }

                        var dto = new ExternalPropertyDto
                        {
                            SourceName = _settings.SourceName,
                            SourceUrl = sourceUrl,
                            Title = ExtractTitle(node) ?? "(Sem título)",
                            ImageUrl = ExtractImageUrl(node),
                            Neighborhood = ExtractLocation(node) ?? string.Empty,
                        };

                        var price = ExtractPrice(node);
                        dto.Price = price ?? 0m;

                        dto.ExternalId = ExtractExternalId(sourceUrl) ?? GenerateHash(dto.SourceName + dto.SourceUrl);

                        results.Add(dto);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogWarning(ex, "Error parsing a listing card, skipping.");
                        continue;
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "Error fetching/parsing OLX page {Page}", page);
            }

            await Task.Delay(TimeSpan.FromSeconds(Math.Max(1, _settings.DelayBetweenRequestsInSeconds)));
        }

        _logger.LogInformation("OLX collection finished. Total normalized: {Count}", results.Count);
        return results;
    }

    private static List<HtmlNode> FindListingNodes(HtmlDocument doc)
    {
        // Try several strategies to find listing cards
        var list = new List<HtmlNode>();

        // strategy 1: data-testid="ad-card"
        list.AddRange(doc.DocumentNode.SelectNodes("//*[@data-testid='ad-card']") ?? Enumerable.Empty<HtmlNode>());

        // strategy 2: nodes with links to /imoveis/
        var links = doc.DocumentNode.SelectNodes("//a[contains(@href,'/imoveis/')]") ?? Enumerable.Empty<HtmlNode>();
        foreach (var a in links)
        {
            var parent = a.AncestorsAndSelf().FirstOrDefault(n => n.Name == "li" || n.Name == "article" || n.Name == "div");
            if (parent != null && !list.Contains(parent)) list.Add(parent);
        }

        // strategy 3: items with class containing 'sc-' or 'ad-list'
        var possible = doc.DocumentNode.SelectNodes("//*[contains(@class,'ad-list') or contains(@class,'sc-')]") ?? Enumerable.Empty<HtmlNode>();
        foreach (var n in possible)
        {
            if (!list.Contains(n)) list.Add(n);
        }

        return list.Distinct().ToList();
    }

    private static string? ExtractTitle(HtmlNode node)
    {
        var title = node.SelectSingleNode(".//h2")?.InnerText
            ?? node.SelectSingleNode(".//h3")?.InnerText
            ?? node.SelectSingleNode(".//*[@data-testid='ad-title']")?.InnerText;

        return NormalizeText(title);
    }

    private static decimal? ExtractPrice(HtmlNode node)
    {
        var txt = node.SelectSingleNode(".//*[@data-testid='ad-price']")?.InnerText
            ?? node.SelectSingleNode(".//*[contains(@class,'price')]")?.InnerText;

        return ParseDecimalPrice(txt);
    }

    private static string? ExtractLocation(HtmlNode node)
    {
        var txt = node.SelectSingleNode(".//*[contains(@class,'location')]")?.InnerText
            ?? node.SelectSingleNode(".//*[contains(@class,'ad-location')]")?.InnerText;

        return NormalizeText(txt);
    }

    private static string? ExtractImageUrl(HtmlNode node)
    {
        var img = node.SelectSingleNode(".//img[@src]") ?? node.SelectSingleNode(".//img[@data-src]");
        var url = img?.GetAttributeValue("src", null) ?? img?.GetAttributeValue("data-src", null);
        return string.IsNullOrWhiteSpace(url) ? null : url;
    }

    private static string? ExtractSourceUrl(HtmlNode node)
    {
        var a = node.SelectSingleNode(".//a[contains(@href,'/imoveis/')]") ?? node.SelectSingleNode(".//a[@data-testid='ad-link']");
        var href = a?.GetAttributeValue("href", null);
        if (string.IsNullOrWhiteSpace(href)) return null;
        // Ensure absolute
        if (href.StartsWith("//")) href = "https:" + href;
        if (href.StartsWith("/")) href = "https://www.olx.com.br" + href;
        return href;
    }

    private static string? ExtractExternalId(string? sourceUrl)
    {
        if (string.IsNullOrWhiteSpace(sourceUrl)) return null;

        try
        {
            var uri = new Uri(sourceUrl);
            // OLX often includes an ID segment at the end
            var parts = uri.Segments.Select(s => s.Trim('/')).Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();
            if (parts.Length == 0) return null;

            var last = parts.Last();
            // If last contains a numeric id or hyphenated id, use it
            if (last.Any(char.IsDigit)) return last;
            return null;
        }
        catch
        {
            return null;
        }
    }

    private static decimal? ParseDecimalPrice(string? text)
    {
        if (string.IsNullOrWhiteSpace(text)) return null;
        var cleaned = new string(text.Where(c => char.IsDigit(c) || c == ',' || c == '.').ToArray());
        if (string.IsNullOrWhiteSpace(cleaned)) return null;
        // Replace thousand separators
        cleaned = cleaned.Replace(".", string.Empty).Replace(",", ".");
        if (decimal.TryParse(cleaned, System.Globalization.NumberStyles.Number, System.Globalization.CultureInfo.InvariantCulture, out var v))
            return v;
        return null;
    }

    private static string? NormalizeText(string? text)
    {
        if (string.IsNullOrWhiteSpace(text)) return null;
        var t = HtmlEntity.DeEntitize(text).Trim();
        return string.Join(' ', t.Split(new[] { '\r', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim()));
    }

    private static string GenerateHash(string input)
    {
        using var sha = System.Security.Cryptography.SHA256.Create();
        var bytes = System.Text.Encoding.UTF8.GetBytes(input);
        var hash = sha.ComputeHash(bytes);
        return BitConverter.ToString(hash).Replace("-", string.Empty).ToLowerInvariant().Substring(0, 20);
    }
}
