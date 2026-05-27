using BuscaImovel.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace BuscaImovel.Api.Data
{
    public class BuscaImovelDbContext : DbContext
    {
        public BuscaImovelDbContext(DbContextOptions<BuscaImovelDbContext> options)
            : base(options)
        {
        }

        public DbSet<Property> Properties => Set<Property>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Property>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Title).IsRequired();
                entity.Property(x => x.Description).IsRequired();
                entity.Property(x => x.TransactionType).IsRequired();
                entity.Property(x => x.PropertyType).IsRequired();
                entity.Property(x => x.Neighborhood).IsRequired();
                entity.Property(x => x.City).IsRequired();
                entity.Property(x => x.SourceName).IsRequired();
                entity.Property(x => x.SourceUrl).IsRequired();
                entity.Property(x => x.IsActive).IsRequired();
                entity.HasIndex(x => new { x.SourceName, x.ExternalId });
            });

            modelBuilder.Entity<Property>().HasData(
                new Property
                {
                    Id = Guid.NewGuid(),
                    ExternalId = "seed-001",
                    Title = "Apartamento mobiliado em Moema",
                    Description = "Apartamento 2 dormitórios, mobiliado, composto por sala integrada, cozinha americana e varanda.",
                    TransactionType = "Rent",
                    PropertyType = "Apartment",
                    Price = 5200m,
                    CondoFee = 950m,
                    Iptu = 180m,
                    Area = 68m,
                    Bedrooms = 2,
                    Bathrooms = 2,
                    ParkingSpaces = 1,
                    Neighborhood = "Moema",
                    City = "São Paulo",
                    Address = "Avenida Ibirapuera, 1234",
                    IsPetFriendly = true,
                    IsFurnished = true,
                    SourceName = "QuintoAndar",
                    SourceUrl = "https://www.quintoandar.com.br/imovel/moema",
                    ImageUrl = "https://example.com/images/moema.jpg",
                    LastSeenAt = DateTime.UtcNow,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                },
                new Property
                {
                    Id = Guid.NewGuid(),
                    ExternalId = "seed-002",
                    Title = "House com quintal em Vila Mariana",
                    Description = "Casa térrea com 3 quartos, quintal e área gourmet próxima ao metrô.",
                    TransactionType = "Sale",
                    PropertyType = "House",
                    Price = 1450000m,
                    CondoFee = 0m,
                    Iptu = 120m,
                    Area = 150m,
                    Bedrooms = 3,
                    Bathrooms = 3,
                    ParkingSpaces = 2,
                    Neighborhood = "Vila Mariana",
                    City = "São Paulo",
                    Address = "Rua Sena Madureira, 987",
                    IsPetFriendly = true,
                    IsFurnished = false,
                    SourceName = "Zap Imóveis",
                    SourceUrl = "https://www.zapimoveis.com.br/imovel/vila-mariana",
                    ImageUrl = "https://example.com/images/vila-mariana.jpg",
                    LastSeenAt = DateTime.UtcNow,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                },
                new Property
                {
                    Id = Guid.NewGuid(),
                    ExternalId = "seed-003",
                    Title = "Studio moderno em Santana",
                    Description = "Studio compacto com área de serviço, ideal para estudante ou jovem profissional.",
                    TransactionType = "Rent",
                    PropertyType = "Studio",
                    Price = 2200m,
                    CondoFee = 420m,
                    Iptu = 90m,
                    Area = 32m,
                    Bedrooms = 0,
                    Bathrooms = 1,
                    ParkingSpaces = 0,
                    Neighborhood = "Santana",
                    City = "São Paulo",
                    Address = "Av. Cruzeiro do Sul, 3450",
                    IsPetFriendly = false,
                    IsFurnished = true,
                    SourceName = "OLX",
                    SourceUrl = "https://www.olx.com.br/imovel/santana",
                    ImageUrl = "https://example.com/images/santana.jpg",
                    LastSeenAt = DateTime.UtcNow,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                },
                new Property
                {
                    Id = Guid.NewGuid(),
                    ExternalId = "seed-004",
                    Title = "Apartamento amplo em Pinheiros",
                    Description = "Apartamento em andar alto, 3 dormitórios, sala ampla e excelente iluminação.",
                    TransactionType = "Sale",
                    PropertyType = "Apartment",
                    Price = 2200000m,
                    CondoFee = 1300m,
                    Iptu = 260m,
                    Area = 120m,
                    Bedrooms = 3,
                    Bathrooms = 3,
                    ParkingSpaces = 2,
                    Neighborhood = "Pinheiros",
                    City = "São Paulo",
                    Address = "Rua Henrique Schaumann, 789",
                    IsPetFriendly = true,
                    IsFurnished = false,
                    SourceName = "Viva Real",
                    SourceUrl = "https://www.vivareal.com.br/imovel/pinheiros",
                    ImageUrl = "https://example.com/images/pinheiros.jpg",
                    LastSeenAt = DateTime.UtcNow,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                },
                new Property
                {
                    Id = Guid.NewGuid(),
                    ExternalId = "seed-005",
                    Title = "Cobertura duplex em Perdizes",
                    Description = "Cobertura com 4 dormitórios, terraço e área de lazer privativa.",
                    TransactionType = "Sale",
                    PropertyType = "Apartment",
                    Price = 3980000m,
                    CondoFee = 2300m,
                    Iptu = 520m,
                    Area = 220m,
                    Bedrooms = 4,
                    Bathrooms = 4,
                    ParkingSpaces = 3,
                    Neighborhood = "Perdizes",
                    City = "São Paulo",
                    Address = "Rua Turiassu, 1550",
                    IsPetFriendly = true,
                    IsFurnished = false,
                    SourceName = "Imovelweb",
                    SourceUrl = "https://www.imovelweb.com.br/imovel/perdizes",
                    ImageUrl = "https://example.com/images/perdizes.jpg",
                    LastSeenAt = DateTime.UtcNow,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                },
                new Property
                {
                    Id = Guid.NewGuid(),
                    ExternalId = "seed-006",
                    Title = "Apartamento compacto em Tatuapé",
                    Description = "Imóvel pronto para morar com 1 dormitório e varanda.",
                    TransactionType = "Rent",
                    PropertyType = "Apartment",
                    Price = 2600m,
                    CondoFee = 620m,
                    Iptu = 110m,
                    Area = 45m,
                    Bedrooms = 1,
                    Bathrooms = 1,
                    ParkingSpaces = 1,
                    Neighborhood = "Tatuapé",
                    City = "São Paulo",
                    Address = "Rua Itapura, 2150",
                    IsPetFriendly = false,
                    IsFurnished = false,
                    SourceName = "QuintoAndar",
                    SourceUrl = "https://www.quintoandar.com.br/imovel/tatuape",
                    ImageUrl = "https://example.com/images/tatuape.jpg",
                    LastSeenAt = DateTime.UtcNow,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                },
                new Property
                {
                    Id = Guid.NewGuid(),
                    ExternalId = "seed-007",
                    Title = "Casa com área gourmet no Brooklin",
                    Description = "Casa isolada com 3 suítes, piscina e jardim.",
                    TransactionType = "Sale",
                    PropertyType = "House",
                    Price = 2200000m,
                    CondoFee = 0m,
                    Iptu = 350m,
                    Area = 180m,
                    Bedrooms = 3,
                    Bathrooms = 4,
                    ParkingSpaces = 3,
                    Neighborhood = "Brooklin",
                    City = "São Paulo",
                    Address = "Rua Lemos Monteiro, 220",
                    IsPetFriendly = true,
                    IsFurnished = false,
                    SourceName = "Zap Imóveis",
                    SourceUrl = "https://www.zapimoveis.com.br/imovel/brooklin",
                    ImageUrl = "https://example.com/images/brooklin.jpg",
                    LastSeenAt = DateTime.UtcNow,
                    IsActive = true,
                    CreatedAt = DateTime.UtcNow,
                });
        }
    }
}
