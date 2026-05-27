using BuscaImovel.Api.Data;
using BuscaImovel.Collectors.Collectors;
using BuscaImovel.Collectors.Models;
using BuscaImovel.Collectors.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((context, config) =>
    {
        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
    })
    .ConfigureServices((context, services) =>
    {
        var configuration = context.Configuration;
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<BuscaImovelDbContext>(options =>
            options.UseSqlite(connectionString));

        services.AddScoped<IPropertyCollector, FakePropertyCollector>();
        services.AddScoped<PropertyImportService>();
    })
    .ConfigureLogging(logging =>
    {
        logging.ClearProviders();
        logging.AddConsole();
    })
    .Build();

using var scope = host.Services.CreateScope();
var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
var collector = scope.ServiceProvider.GetRequiredService<IPropertyCollector>();
var importService = scope.ServiceProvider.GetRequiredService<PropertyImportService>();

try
{
    logger.LogInformation("Iniciando coleta de imóveis...");
    var properties = await collector.CollectAsync();
    var result = await importService.ImportAsync(properties);

    logger.LogInformation("Importação finalizada.");
    logger.LogInformation("Total coletado: {Collected}", result.Collected);
    logger.LogInformation("Total inserido: {Inserted}", result.Inserted);
    logger.LogInformation("Total atualizado: {Updated}", result.Updated);
    logger.LogInformation("Total pulado: {Skipped}", result.Skipped);

    if (result.Errors.Count > 0)
    {
        logger.LogError("Ocorreram erros durante a importação:");
        foreach (var error in result.Errors)
        {
            logger.LogError(error);
        }
    }
}
catch (Exception ex)
{
    logger.LogError(ex, "Erro inesperado no collector.");
}
