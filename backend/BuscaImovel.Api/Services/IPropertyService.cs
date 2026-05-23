using BuscaImovel.Api.DTOs;

namespace BuscaImovel.Api.Services
{
    public interface IPropertyService
    {
        Task<IEnumerable<PropertyResponseDto>> GetPropertiesAsync(PropertyFilterRequestDto filter);
        Task<PropertyResponseDto?> GetPropertyByIdAsync(Guid id);
        Task<IEnumerable<string>> GetNeighborhoodsAsync();
        Task<IEnumerable<string>> GetSourcesAsync();
    }
}
