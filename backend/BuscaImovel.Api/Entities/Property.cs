using System.ComponentModel.DataAnnotations.Schema;

namespace BuscaImovel.Api.Entities
{
    public class Property
    {
        public Guid Id { get; set; }
        public string? ExternalId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string TransactionType { get; set; } = null!;
        public string PropertyType { get; set; } = null!;
        public decimal Price { get; set; }
        public decimal? CondoFee { get; set; }
        public decimal? Iptu { get; set; }
        public decimal Area { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public int ParkingSpaces { get; set; }
        public string Neighborhood { get; set; } = null!;
        public string City { get; set; } = null!;
        public string? Address { get; set; }
        public bool IsPetFriendly { get; set; }
        public bool IsFurnished { get; set; }
        public string SourceName { get; set; } = null!;
        public string SourceUrl { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public DateTime? LastSeenAt { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        [NotMapped]
        public decimal TotalMonthlyCost => Price + (CondoFee ?? 0m) + (Iptu ?? 0m);

        [NotMapped]
        public decimal PricePerSquareMeter => Area > 0 ? Price / Area : 0m;
    }
}
