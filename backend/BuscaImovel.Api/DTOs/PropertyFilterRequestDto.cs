namespace BuscaImovel.Api.DTOs
{
    public class PropertyFilterRequestDto
    {
        public string? Query { get; set; }
        public string? TransactionType { get; set; }
        public string? PropertyType { get; set; }
        public string? Neighborhood { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int? MinBedrooms { get; set; }
        public int? MinParkingSpaces { get; set; }
        public decimal? MinArea { get; set; }
        public bool? IsPetFriendly { get; set; }
        public bool? IsFurnished { get; set; }
        public string? SourceName { get; set; }
    }
}
