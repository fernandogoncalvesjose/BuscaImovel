using BuscaImovel.Api.Data;
using BuscaImovel.Api.DTOs;
using BuscaImovel.Api.Mappings;
using Microsoft.EntityFrameworkCore;

namespace BuscaImovel.Api.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly BuscaImovelDbContext _dbContext;

        public PropertyService(BuscaImovelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<PropertyResponseDto>> GetPropertiesAsync(PropertyFilterRequestDto filter)
        {
            var query = _dbContext.Properties.AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.TransactionType))
            {
                query = query.Where(x => x.TransactionType == filter.TransactionType);
            }

            if (!string.IsNullOrWhiteSpace(filter.PropertyType))
            {
                query = query.Where(x => x.PropertyType == filter.PropertyType);
            }

            if (!string.IsNullOrWhiteSpace(filter.Neighborhood))
            {
                query = query.Where(x => x.Neighborhood == filter.Neighborhood);
            }

            if (filter.MinPrice.HasValue)
            {
                query = query.Where(x => x.Price >= filter.MinPrice.Value);
            }

            if (filter.MaxPrice.HasValue)
            {
                query = query.Where(x => x.Price <= filter.MaxPrice.Value);
            }

            if (filter.MinBedrooms.HasValue)
            {
                query = query.Where(x => x.Bedrooms >= filter.MinBedrooms.Value);
            }

            if (filter.MinParkingSpaces.HasValue)
            {
                query = query.Where(x => x.ParkingSpaces >= filter.MinParkingSpaces.Value);
            }

            if (filter.MinArea.HasValue)
            {
                query = query.Where(x => x.Area >= filter.MinArea.Value);
            }

            if (filter.IsPetFriendly.HasValue)
            {
                query = query.Where(x => x.IsPetFriendly == filter.IsPetFriendly.Value);
            }

            if (filter.IsFurnished.HasValue)
            {
                query = query.Where(x => x.IsFurnished == filter.IsFurnished.Value);
            }

            if (!string.IsNullOrWhiteSpace(filter.SourceName))
            {
                query = query.Where(x => x.SourceName == filter.SourceName);
            }

            var properties = await query.ToListAsync();
            return properties
                .OrderBy(x => x.Price)
                .Select(x => x.ToResponseDto());
        }

        public async Task<PropertyResponseDto?> GetPropertyByIdAsync(Guid id)
        {
            var property = await _dbContext.Properties.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return property?.ToResponseDto();
        }

        public async Task<IEnumerable<string>> GetNeighborhoodsAsync()
        {
            return await _dbContext.Properties
                .AsNoTracking()
                .Select(x => x.Neighborhood)
                .Distinct()
                .OrderBy(x => x)
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> GetSourcesAsync()
        {
            return await _dbContext.Properties
                .AsNoTracking()
                .Select(x => x.SourceName)
                .Distinct()
                .OrderBy(x => x)
                .ToListAsync();
        }
    }
}
