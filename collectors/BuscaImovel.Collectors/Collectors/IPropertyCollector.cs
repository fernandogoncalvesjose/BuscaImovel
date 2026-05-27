using BuscaImovel.Collectors.Models;

namespace BuscaImovel.Collectors.Collectors
{
    public interface IPropertyCollector
    {
        Task<IEnumerable<ExternalPropertyDto>> CollectAsync();
    }
}
