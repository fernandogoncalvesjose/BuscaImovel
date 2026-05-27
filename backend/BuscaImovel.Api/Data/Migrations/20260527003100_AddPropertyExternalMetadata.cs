using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BuscaImovel.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertyExternalMetadata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("04cf31a6-7367-4821-95a8-f29b1252c909"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("1aae2288-30a2-4162-bea9-e316c70db978"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("225ca4b4-4cc6-4c95-b3b2-361336cfa14a"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("2b2c6278-2def-4095-9dd1-ecadaa9d31a7"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("3ecc7965-9194-4799-9746-51e8f3a7e2a0"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("55ebef17-9ff6-4b45-809b-c31c0c1bbad3"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("58b3e2d1-8a66-472f-ad60-133f7ce5ddd3"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("5ce729b8-aa32-46f8-8352-fc58eaa8b66e"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("715d3a10-e142-4a9e-bd3f-7619beb06f84"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("7694236c-46d0-4772-96d7-4fb5d9546295"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("832f1d2a-61f6-48e2-85f1-d15ebf99be0b"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("d24c1608-9b71-4a44-a038-66a6467a2921"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("de46cc1d-697d-4f0d-aab8-adbc8fda0ccf"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("ea7a6bef-5dc2-40dd-9317-896f96642eab"));

            migrationBuilder.AddColumn<string>(
                name: "ExternalId",
                table: "Properties",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Properties",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastSeenAt",
                table: "Properties",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "Area", "Bathrooms", "Bedrooms", "City", "CondoFee", "CreatedAt", "Description", "ExternalId", "ImageUrl", "Iptu", "IsActive", "IsFurnished", "IsPetFriendly", "LastSeenAt", "Neighborhood", "ParkingSpaces", "Price", "PropertyType", "SourceName", "SourceUrl", "Title", "TransactionType", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("08c3e6e9-b04f-4a22-af24-8f62559bbedc"), "Rua Henrique Schaumann, 789", 120m, 3, 3, "São Paulo", 1300m, new DateTime(2026, 5, 27, 0, 30, 59, 508, DateTimeKind.Utc).AddTicks(6137), "Apartamento em andar alto, 3 dormitórios, sala ampla e excelente iluminação.", "seed-004", "https://example.com/images/pinheiros.jpg", 260m, true, false, true, new DateTime(2026, 5, 27, 0, 30, 59, 508, DateTimeKind.Utc).AddTicks(6136), "Pinheiros", 2, 2200000m, "Apartment", "Viva Real", "https://www.vivareal.com.br/imovel/pinheiros", "Apartamento amplo em Pinheiros", "Sale", null },
                    { new Guid("3e42bfa9-e55c-4e95-9f62-bcb0d986ace9"), "Rua Turiassu, 1550", 220m, 4, 4, "São Paulo", 2300m, new DateTime(2026, 5, 27, 0, 30, 59, 508, DateTimeKind.Utc).AddTicks(6156), "Cobertura com 4 dormitórios, terraço e área de lazer privativa.", "seed-005", "https://example.com/images/perdizes.jpg", 520m, true, false, true, new DateTime(2026, 5, 27, 0, 30, 59, 508, DateTimeKind.Utc).AddTicks(6144), "Perdizes", 3, 3980000m, "Apartment", "Imovelweb", "https://www.imovelweb.com.br/imovel/perdizes", "Cobertura duplex em Perdizes", "Sale", null },
                    { new Guid("655aae35-a729-4d5d-aeb2-5b1e91292cbd"), "Avenida Ibirapuera, 1234", 68m, 2, 2, "São Paulo", 950m, new DateTime(2026, 5, 27, 0, 30, 59, 508, DateTimeKind.Utc).AddTicks(6111), "Apartamento 2 dormitórios, mobiliado, composto por sala integrada, cozinha americana e varanda.", "seed-001", "https://example.com/images/moema.jpg", 180m, true, true, true, new DateTime(2026, 5, 27, 0, 30, 59, 508, DateTimeKind.Utc).AddTicks(6107), "Moema", 1, 5200m, "Apartment", "QuintoAndar", "https://www.quintoandar.com.br/imovel/moema", "Apartamento mobiliado em Moema", "Rent", null },
                    { new Guid("65fb3089-8185-4df1-9474-cfd926fb046e"), "Av. Cruzeiro do Sul, 3450", 32m, 1, 0, "São Paulo", 420m, new DateTime(2026, 5, 27, 0, 30, 59, 508, DateTimeKind.Utc).AddTicks(6130), "Studio compacto com área de serviço, ideal para estudante ou jovem profissional.", "seed-003", "https://example.com/images/santana.jpg", 90m, true, true, false, new DateTime(2026, 5, 27, 0, 30, 59, 508, DateTimeKind.Utc).AddTicks(6128), "Santana", 0, 2200m, "Studio", "OLX", "https://www.olx.com.br/imovel/santana", "Studio moderno em Santana", "Rent", null },
                    { new Guid("6dc5f08e-c3bb-4469-8c2b-721891e6a7f2"), "Rua Itapura, 2150", 45m, 1, 1, "São Paulo", 620m, new DateTime(2026, 5, 27, 0, 30, 59, 508, DateTimeKind.Utc).AddTicks(6163), "Imóvel pronto para morar com 1 dormitório e varanda.", "seed-006", "https://example.com/images/tatuape.jpg", 110m, true, false, false, new DateTime(2026, 5, 27, 0, 30, 59, 508, DateTimeKind.Utc).AddTicks(6162), "Tatuapé", 1, 2600m, "Apartment", "QuintoAndar", "https://www.quintoandar.com.br/imovel/tatuape", "Apartamento compacto em Tatuapé", "Rent", null },
                    { new Guid("d49fc4b9-896a-4b4c-aa54-20fe1eb690fc"), "Rua Sena Madureira, 987", 150m, 3, 3, "São Paulo", 0m, new DateTime(2026, 5, 27, 0, 30, 59, 508, DateTimeKind.Utc).AddTicks(6121), "Casa térrea com 3 quartos, quintal e área gourmet próxima ao metrô.", "seed-002", "https://example.com/images/vila-mariana.jpg", 120m, true, false, true, new DateTime(2026, 5, 27, 0, 30, 59, 508, DateTimeKind.Utc).AddTicks(6120), "Vila Mariana", 2, 1450000m, "House", "Zap Imóveis", "https://www.zapimoveis.com.br/imovel/vila-mariana", "House com quintal em Vila Mariana", "Sale", null },
                    { new Guid("e0698619-918e-4ba7-bf3a-e755e3cdf1a0"), "Rua Lemos Monteiro, 220", 180m, 4, 3, "São Paulo", 0m, new DateTime(2026, 5, 27, 0, 30, 59, 508, DateTimeKind.Utc).AddTicks(6169), "Casa isolada com 3 suítes, piscina e jardim.", "seed-007", "https://example.com/images/brooklin.jpg", 350m, true, false, true, new DateTime(2026, 5, 27, 0, 30, 59, 508, DateTimeKind.Utc).AddTicks(6168), "Brooklin", 3, 2200000m, "House", "Zap Imóveis", "https://www.zapimoveis.com.br/imovel/brooklin", "Casa com área gourmet no Brooklin", "Sale", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_SourceName_ExternalId",
                table: "Properties",
                columns: new[] { "SourceName", "ExternalId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Properties_SourceName_ExternalId",
                table: "Properties");

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("08c3e6e9-b04f-4a22-af24-8f62559bbedc"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("3e42bfa9-e55c-4e95-9f62-bcb0d986ace9"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("655aae35-a729-4d5d-aeb2-5b1e91292cbd"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("65fb3089-8185-4df1-9474-cfd926fb046e"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("6dc5f08e-c3bb-4469-8c2b-721891e6a7f2"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("d49fc4b9-896a-4b4c-aa54-20fe1eb690fc"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("e0698619-918e-4ba7-bf3a-e755e3cdf1a0"));

            migrationBuilder.DropColumn(
                name: "ExternalId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "LastSeenAt",
                table: "Properties");

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "Area", "Bathrooms", "Bedrooms", "City", "CondoFee", "CreatedAt", "Description", "ImageUrl", "Iptu", "IsFurnished", "IsPetFriendly", "Neighborhood", "ParkingSpaces", "Price", "PropertyType", "SourceName", "SourceUrl", "Title", "TransactionType", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("04cf31a6-7367-4821-95a8-f29b1252c909"), "Rua Henrique Schaumann, 789", 120m, 3, 3, "São Paulo", 1300m, new DateTime(2026, 5, 23, 20, 18, 20, 802, DateTimeKind.Utc).AddTicks(59), "Apartamento em andar alto, 3 dormitórios, sala ampla e excelente iluminação.", "https://example.com/images/pinheiros.jpg", 260m, false, true, "Pinheiros", 2, 2200000m, "Apartment", "Viva Real", "https://www.vivareal.com.br/imovel/pinheiros", "Apartamento amplo em Pinheiros", "Sale", null },
                    { new Guid("1aae2288-30a2-4162-bea9-e316c70db978"), "Rua do Rocio, 1600", 110m, 3, 2, "São Paulo", 1400m, new DateTime(2026, 5, 23, 20, 18, 20, 802, DateTimeKind.Utc).AddTicks(164), "2 dormitórios com varanda e lazer completo.", "https://example.com/images/brooklin-sale.jpg", 310m, false, true, "Brooklin", 2, 2550000m, "Apartment", "OLX", "https://www.olx.com.br/imovel/brooklin", "Apartamento com vista no Brooklin", "Sale", null },
                    { new Guid("225ca4b4-4cc6-4c95-b3b2-361336cfa14a"), "Avenida Sumaré, 500", 30m, 1, 0, "São Paulo", 520m, new DateTime(2026, 5, 23, 20, 18, 20, 802, DateTimeKind.Utc).AddTicks(155), "Studio com cozinha integrada e ótima localização.", "https://example.com/images/perdizes-studio.jpg", 105m, true, false, "Perdizes", 0, 2100m, "Studio", "Zap Imóveis", "https://www.zapimoveis.com.br/imovel/perdizes", "Apartamento studio em Perdizes", "Rent", null },
                    { new Guid("2b2c6278-2def-4095-9dd1-ecadaa9d31a7"), "Av. Corifeu de Azevedo Marques, 1120", 62m, 2, 2, "São Paulo", 540m, new DateTime(2026, 5, 23, 20, 18, 20, 802, DateTimeKind.Utc).AddTicks(110), "Apartamento com varanda, área de serviço, vaga de garagem e lazer completo.", "https://example.com/images/butanta.jpg", 130m, false, true, "Butantã", 1, 2900m, "Apartment", "Imovelweb", "https://www.imovelweb.com.br/imovel/butanta", "Apartamento 2 quartos no Butantã", "Rent", null },
                    { new Guid("3ecc7965-9194-4799-9746-51e8f3a7e2a0"), "Rua Lemos Monteiro, 220", 180m, 4, 3, "São Paulo", 0m, new DateTime(2026, 5, 23, 20, 18, 20, 802, DateTimeKind.Utc).AddTicks(101), "Casa isolada com 3 suítes, piscina e jardim.", "https://example.com/images/brooklin.jpg", 350m, false, true, "Brooklin", 3, 2200000m, "House", "Zap Imóveis", "https://www.zapimoveis.com.br/imovel/brooklin", "Casa com área gourmet no Brooklin", "Sale", null },
                    { new Guid("55ebef17-9ff6-4b45-809b-c31c0c1bbad3"), "Rua Turiassu, 1550", 220m, 4, 4, "São Paulo", 2300m, new DateTime(2026, 5, 23, 20, 18, 20, 802, DateTimeKind.Utc).AddTicks(67), "Cobertura com 4 dormitórios, terraço e área de lazer privativa.", "https://example.com/images/perdizes.jpg", 520m, false, true, "Perdizes", 3, 3980000m, "Apartment", "Imovelweb", "https://www.imovelweb.com.br/imovel/perdizes", "Cobertura duplex em Perdizes", "Sale", null },
                    { new Guid("58b3e2d1-8a66-472f-ad60-133f7ce5ddd3"), "Avenida Ibirapuera, 1234", 68m, 2, 2, "São Paulo", 950m, new DateTime(2026, 5, 23, 20, 18, 20, 802, DateTimeKind.Utc).AddTicks(25), "Apartamento 2 dormitórios, mobiliado, composto por sala integrada, cozinha americana e varanda.", "https://example.com/images/moema.jpg", 180m, true, true, "Moema", 1, 5200m, "Apartment", "QuintoAndar", "https://www.quintoandar.com.br/imovel/moema", "Apartamento mobiliado em Moema", "Rent", null },
                    { new Guid("5ce729b8-aa32-46f8-8352-fc58eaa8b66e"), "Av. Cruzeiro do Sul, 3450", 32m, 1, 0, "São Paulo", 420m, new DateTime(2026, 5, 23, 20, 18, 20, 802, DateTimeKind.Utc).AddTicks(49), "Studio compacto com área de serviço, ideal para estudante ou jovem profissional.", "https://example.com/images/santana.jpg", 90m, true, false, "Santana", 0, 2200m, "Studio", "OLX", "https://www.olx.com.br/imovel/santana", "Studio moderno em Santana", "Rent", null },
                    { new Guid("715d3a10-e142-4a9e-bd3f-7619beb06f84"), "Rua Serra de Bragança, 210", 140m, 3, 3, "São Paulo", 0m, new DateTime(2026, 5, 23, 20, 18, 20, 802, DateTimeKind.Utc).AddTicks(145), "Casa com 3 quartos, quintal e churrasqueira.", "https://example.com/images/tatuape-house.jpg", 280m, false, true, "Tatuapé", 2, 1850000m, "House", "Imovelweb", "https://www.imovelweb.com.br/imovel/tatuape", "Casa em rua tranquila no Tatuapé", "Sale", null },
                    { new Guid("7694236c-46d0-4772-96d7-4fb5d9546295"), "Rua Sena Madureira, 987", 150m, 3, 3, "São Paulo", 0m, new DateTime(2026, 5, 23, 20, 18, 20, 802, DateTimeKind.Utc).AddTicks(40), "Casa térrea com 3 quartos, quintal e área gourmet próxima ao metrô.", "https://example.com/images/vila-mariana.jpg", 120m, false, true, "Vila Mariana", 2, 1450000m, "House", "Zap Imóveis", "https://www.zapimoveis.com.br/imovel/vila-mariana", "House com quintal em Vila Mariana", "Sale", null },
                    { new Guid("832f1d2a-61f6-48e2-85f1-d15ebf99be0b"), "Rua da Saúde, 442", 28m, 1, 0, "São Paulo", 460m, new DateTime(2026, 5, 23, 20, 18, 20, 802, DateTimeKind.Utc).AddTicks(118), "Studio mobiliado com cozinha planejada e vista para a cidade.", "https://example.com/images/saude.jpg", 95m, true, false, "Saúde", 0, 2350m, "Studio", "OLX", "https://www.olx.com.br/imovel/saude", "Studio próximo ao metrô Saúde", "Rent", null },
                    { new Guid("d24c1608-9b71-4a44-a038-66a6467a2921"), "Rua da Mooca, 1020", 75m, 2, 2, "São Paulo", 780m, new DateTime(2026, 5, 23, 20, 18, 20, 802, DateTimeKind.Utc).AddTicks(136), "Apartamento 2 dormitórios, cozinha espaçosa e pronto para morar.", "https://example.com/images/mooca.jpg", 160m, false, true, "Mooca", 1, 3200m, "Apartment", "QuintoAndar", "https://www.quintoandar.com.br/imovel/mooca", "Apartamento confortável na Mooca", "Rent", null },
                    { new Guid("de46cc1d-697d-4f0d-aab8-adbc8fda0ccf"), "Rua Domingos de Morais, 2050", 55m, 1, 1, "São Paulo", 750m, new DateTime(2026, 5, 23, 20, 18, 20, 802, DateTimeKind.Utc).AddTicks(127), "Apartamento 1 dormitório com cozinha americana e excelente localização.", "https://example.com/images/bela-vista.jpg", 210m, false, true, "Bela Vista", 1, 980000m, "Apartment", "Viva Real", "https://www.vivareal.com.br/imovel/bela-vista", "Apartamento novo na Bela Vista", "Sale", null },
                    { new Guid("ea7a6bef-5dc2-40dd-9317-896f96642eab"), "Rua Itapura, 2150", 45m, 1, 1, "São Paulo", 620m, new DateTime(2026, 5, 23, 20, 18, 20, 802, DateTimeKind.Utc).AddTicks(76), "Imóvel pronto para morar com 1 dormitório e varanda.", "https://example.com/images/tatuape.jpg", 110m, false, false, "Tatuapé", 1, 2600m, "Apartment", "QuintoAndar", "https://www.quintoandar.com.br/imovel/tatuape", "Apartamento compacto em Tatuapé", "Rent", null }
                });
        }
    }
}
