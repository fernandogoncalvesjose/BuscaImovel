using BuscaImovel.Collectors.Models;

namespace BuscaImovel.Collectors.Collectors
{
    public class FakePropertyCollector : IPropertyCollector
    {
        public Task<IEnumerable<ExternalPropertyDto>> CollectAsync()
        {
            var properties = new List<ExternalPropertyDto>
            {
                new ExternalPropertyDto
                {
                    ExternalId = "fake-001",
                    Title = "Apartamento com vista para o parque",
                    Description = "Apartamento de 2 dormitórios com varanda e área de serviço.",
                    TransactionType = "Rent",
                    PropertyType = "Apartment",
                    Price = 3200m,
                    CondoFee = 580m,
                    Iptu = 110m,
                    Area = 72m,
                    Bedrooms = 2,
                    Bathrooms = 2,
                    ParkingSpaces = 1,
                    Neighborhood = "Pinheiros",
                    City = "São Paulo",
                    Address = "Rua dos Pinheiros, 123",
                    IsPetFriendly = true,
                    IsFurnished = true,
                    SourceName = "FakeSource",
                    SourceUrl = "https://fakesource.com/property/fake-001",
                    ImageUrl = "https://example.com/fake-001.jpg"
                },
                new ExternalPropertyDto
                {
                    ExternalId = "fake-002",
                    Title = "Studio compacto próximo ao metrô",
                    Description = "Studio moderno com 1 banheiro e cozinha americana.",
                    TransactionType = "Rent",
                    PropertyType = "Studio",
                    Price = 2100m,
                    CondoFee = 420m,
                    Iptu = 80m,
                    Area = 34m,
                    Bedrooms = 0,
                    Bathrooms = 1,
                    ParkingSpaces = 0,
                    Neighborhood = "Santana",
                    City = "São Paulo",
                    Address = "Avenida Cruzeiro do Sul, 4000",
                    IsPetFriendly = false,
                    IsFurnished = true,
                    SourceName = "FakeSource",
                    SourceUrl = "https://fakesource.com/property/fake-002",
                    ImageUrl = "https://example.com/fake-002.jpg"
                },
                new ExternalPropertyDto
                {
                    ExternalId = "fake-003",
                    Title = "Casa com quintal e churrasqueira",
                    Description = "Casa térrea com 3 quartos e área gourmet privativa.",
                    TransactionType = "Sale",
                    PropertyType = "House",
                    Price = 1450000m,
                    CondoFee = 0m,
                    Iptu = 210m,
                    Area = 160m,
                    Bedrooms = 3,
                    Bathrooms = 3,
                    ParkingSpaces = 2,
                    Neighborhood = "Vila Mariana",
                    City = "São Paulo",
                    Address = "Rua Sena Madureira, 2100",
                    IsPetFriendly = true,
                    IsFurnished = false,
                    SourceName = "FakeSource",
                    SourceUrl = "https://fakesource.com/property/fake-003",
                    ImageUrl = "https://example.com/fake-003.jpg"
                },
                new ExternalPropertyDto
                {
                    ExternalId = "fake-004",
                    Title = "Cobertura duplex com vista ampla",
                    Description = "Cobertura com 4 dormitórios e terraço gourmet.",
                    TransactionType = "Sale",
                    PropertyType = "Apartment",
                    Price = 3800000m,
                    CondoFee = 1800m,
                    Iptu = 520m,
                    Area = 210m,
                    Bedrooms = 4,
                    Bathrooms = 4,
                    ParkingSpaces = 3,
                    Neighborhood = "Perdizes",
                    City = "São Paulo",
                    Address = "Rua Turiassu, 1550",
                    IsPetFriendly = true,
                    IsFurnished = false,
                    SourceName = "FakeSource",
                    SourceUrl = "https://fakesource.com/property/fake-004",
                    ImageUrl = "https://example.com/fake-004.jpg"
                },
                new ExternalPropertyDto
                {
                    ExternalId = "fake-005",
                    Title = "Apartamento novo com varanda gourmet",
                    Description = "Apartamento 3 dormitórios em condomínio com lazer completo.",
                    TransactionType = "Rent",
                    PropertyType = "Apartment",
                    Price = 5200m,
                    CondoFee = 980m,
                    Iptu = 130m,
                    Area = 98m,
                    Bedrooms = 3,
                    Bathrooms = 2,
                    ParkingSpaces = 2,
                    Neighborhood = "Moema",
                    City = "São Paulo",
                    Address = "Avenida Ibirapuera, 987",
                    IsPetFriendly = true,
                    IsFurnished = true,
                    SourceName = "FakeSource",
                    SourceUrl = "https://fakesource.com/property/fake-005",
                    ImageUrl = "https://example.com/fake-005.jpg"
                }
            };

            return Task.FromResult<IEnumerable<ExternalPropertyDto>>(properties);
        }
    }
}
