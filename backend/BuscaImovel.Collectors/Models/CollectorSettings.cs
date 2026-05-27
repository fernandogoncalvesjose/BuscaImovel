namespace BuscaImovel.Collectors.Models
{
    public sealed class CollectorSettings
    {
        public string SourceName { get; set; } = string.Empty;
        public string BaseUrl { get; set; } = string.Empty;
        public string SearchUrl { get; set; } = string.Empty;
        public int MaxPages { get; set; } = 1;
        public int DelayBetweenRequestsInSeconds { get; set; } = 3;
        public bool Enabled { get; set; } = true;
    }
}
