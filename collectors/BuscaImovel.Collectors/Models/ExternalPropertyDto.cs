namespace BuscaImovel.Collectors.Models
{
    public sealed class ExternalPropertyDto
    {
        public string? ExternalId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string TransactionType { get; set; } = string.Empty;
        public string PropertyType { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal? CondoFee { get; set; }
        public decimal? Iptu { get; set; }
        public decimal Area { get; set; }
        public int Bedrooms { get; set; }
        public int Bathrooms { get; set; }
        public int ParkingSpaces { get; set; }
        public string Neighborhood { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string? Address { get; set; }
        public bool IsPetFriendly { get; set; }
        public bool IsFurnished { get; set; }
        public string SourceName { get; set; } = string.Empty;
        public string SourceUrl { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
    }
}
