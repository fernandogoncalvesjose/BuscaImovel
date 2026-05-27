using BuscaImovel.Api.Data;
using BuscaImovel.Api.Entities;
using BuscaImovel.Collectors.Models;
using Microsoft.EntityFrameworkCore;

namespace BuscaImovel.Collectors.Services
{
    public class PropertyImportService
    {
        private readonly BuscaImovelDbContext _dbContext;

        public PropertyImportService(BuscaImovelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ImportResult> ImportAsync(IEnumerable<ExternalPropertyDto> externalProperties)
        {
            var result = new ImportResult();

            foreach (var external in externalProperties)
            {
                result.Collected++;

                if (string.IsNullOrWhiteSpace(external.SourceName))
                {
                    result.Errors.Add($"Propriedade inválida: SourceName ausente para '{external.Title}'.");
                    result.Skipped++;
                    continue;
                }

                if (string.IsNullOrWhiteSpace(external.ExternalId))
                {
                    // Generate deterministic id based on source and url
                    external.ExternalId = GenerateExternalIdFromSourceUrl(external.SourceName, external.SourceUrl);
                }

                result.SourceName ??= external.SourceName;

                var existing = await _dbContext.Properties
                    .FirstOrDefaultAsync(p => p.SourceName == external.SourceName && p.ExternalId == external.ExternalId);

                if (existing is null)
                {
                    var property = MapToProperty(external);
                    property.Id = Guid.NewGuid();
                    property.CreatedAt = DateTime.UtcNow;
                    property.LastSeenAt = DateTime.UtcNow;
                    property.IsActive = true;

                    _dbContext.Properties.Add(property);
                    result.Inserted++;
                    continue;
                }

                existing.LastSeenAt = DateTime.UtcNow;
                existing.IsActive = true;

                if (HasUpdates(existing, external))
                {
                    ApplyUpdates(existing, external);
                    existing.UpdatedAt = DateTime.UtcNow;
                    result.Updated++;
                }
                else
                {
                    result.Skipped++;
                }
            }

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.Errors.Add(ex.Message);
            }

            return result;
        }

        private static Property MapToProperty(ExternalPropertyDto external)
        {
            return new Property
            {
                ExternalId = external.ExternalId,
                Title = external.Title,
                Description = external.Description,
                TransactionType = external.TransactionType,
                PropertyType = external.PropertyType,
                Price = external.Price,
                CondoFee = external.CondoFee,
                Iptu = external.Iptu,
                Area = external.Area,
                Bedrooms = external.Bedrooms,
                Bathrooms = external.Bathrooms,
                ParkingSpaces = external.ParkingSpaces,
                Neighborhood = external.Neighborhood,
                City = external.City,
                Address = external.Address,
                IsPetFriendly = external.IsPetFriendly,
                IsFurnished = external.IsFurnished,
                SourceName = external.SourceName,
                SourceUrl = external.SourceUrl,
                ImageUrl = external.ImageUrl
            };
        }

        private static bool HasUpdates(Property existing, ExternalPropertyDto external)
        {
            return existing.Title != external.Title
                || existing.Description != external.Description
                || existing.TransactionType != external.TransactionType
                || existing.PropertyType != external.PropertyType
                || existing.Price != external.Price
                || existing.CondoFee != external.CondoFee
                || existing.Iptu != external.Iptu
                || existing.Area != external.Area
                || existing.Bedrooms != external.Bedrooms
                || existing.Bathrooms != external.Bathrooms
                || existing.ParkingSpaces != external.ParkingSpaces
                || existing.Neighborhood != external.Neighborhood
                || existing.City != external.City
                || existing.Address != external.Address
                || existing.IsPetFriendly != external.IsPetFriendly
                || existing.IsFurnished != external.IsFurnished
                || existing.SourceUrl != external.SourceUrl
                || existing.ImageUrl != external.ImageUrl;
        }

        private static void ApplyUpdates(Property existing, ExternalPropertyDto external)
        {
            existing.Title = external.Title;
            existing.Description = external.Description;
            existing.TransactionType = external.TransactionType;
            existing.PropertyType = external.PropertyType;
            existing.Price = external.Price;
            existing.CondoFee = external.CondoFee;
            existing.Iptu = external.Iptu;
            existing.Area = external.Area;
            existing.Bedrooms = external.Bedrooms;
            existing.Bathrooms = external.Bathrooms;
            existing.ParkingSpaces = external.ParkingSpaces;
            existing.Neighborhood = external.Neighborhood;
            existing.City = external.City;
            existing.Address = external.Address;
            existing.IsPetFriendly = external.IsPetFriendly;
            existing.IsFurnished = external.IsFurnished;
            existing.SourceUrl = external.SourceUrl;
            existing.ImageUrl = external.ImageUrl;
        }

        private static string GenerateExternalIdFromSourceUrl(string sourceName, string sourceUrl)
        {
            var input = (sourceName ?? string.Empty) + "|" + (sourceUrl ?? string.Empty);
            using var sha = System.Security.Cryptography.SHA256.Create();
            var bytes = System.Text.Encoding.UTF8.GetBytes(input);
            var hash = sha.ComputeHash(bytes);
            return BitConverter.ToString(hash).Replace("-", string.Empty).ToLowerInvariant().Substring(0, 20);
        }
    }
}
