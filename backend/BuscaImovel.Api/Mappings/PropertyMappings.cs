using BuscaImovel.Api.DTOs;
using BuscaImovel.Api.Entities;

namespace BuscaImovel.Api.Mappings
{
    public static class PropertyMappings
    {
        public static PropertyResponseDto ToResponseDto(this Property property)
        {
            return new PropertyResponseDto
            {
                Id = property.Id,
                Title = property.Title,
                Description = property.Description,
                TransactionType = property.TransactionType,
                PropertyType = property.PropertyType,
                Price = property.Price,
                CondoFee = property.CondoFee,
                Iptu = property.Iptu,
                Area = property.Area,
                Bedrooms = property.Bedrooms,
                Bathrooms = property.Bathrooms,
                ParkingSpaces = property.ParkingSpaces,
                Neighborhood = property.Neighborhood,
                City = property.City,
                Address = property.Address,
                IsPetFriendly = property.IsPetFriendly,
                IsFurnished = property.IsFurnished,
                SourceName = property.SourceName,
                SourceUrl = property.SourceUrl,
                ImageUrl = property.ImageUrl,
                CreatedAt = property.CreatedAt,
                UpdatedAt = property.UpdatedAt,
                TotalMonthlyCost = property.TotalMonthlyCost,
                PricePerSquareMeter = property.PricePerSquareMeter,
            };
        }
    }
}
