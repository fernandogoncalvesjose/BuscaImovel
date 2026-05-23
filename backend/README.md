# Busca Imóvel - Backend

API ASP.NET Core para o projeto Busca Imóvel.

## Stack

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQLite
- Swagger

## Estrutura

- `Controllers/`
- `Data/`
- `Entities/`
- `DTOs/`
- `Services/`
- `Mappings/`

## Configuração

A conexão SQLite está em `appsettings.json`:

```json
{
    "ConnectionStrings": {
        "DefaultConnection": "Data Source=buscaimovel.db"
    }
}
```

O projeto também inclui um `NuGet.Config` local em `backend/NuGet.Config` para garantir que o restore use apenas o feed oficial do nuget.org.

## Como rodar

No terminal, a partir de `backend/BuscaImovel.Api`:

```powershell
cd c:\Projetos\BuscaImovel\backend\BuscaImovel.Api
dotnet restore
dotnet build
dotnet run
```

## Aplicar migrations

A migration inicial já foi criada em `Data/Migrations` e o banco pode ser atualizado com:

```powershell
dotnet ef database update
```

## Swagger

A API expõe o Swagger quando executada em modo de desenvolvimento.
Após rodar o projeto, acesse:

`http://localhost:5000/swagger`

ou, se estiver usando outra porta, a URL exibida no console.

## Endpoints principais

- `GET /api/properties`
- `GET /api/properties/{id}`
- `GET /api/properties/neighborhoods`
- `GET /api/properties/sources`
- `GET /api/health`

## Exemplos de chamadas

Buscar propriedades com filtros:

```powershell
curl "http://localhost:5000/api/properties?transactionType=Rent&neighborhood=Moema&minBedrooms=1"
```

Buscar por ID:

```powershell
curl "http://localhost:5000/api/properties/{id}"
```

Buscar bairros disponíveis:

```powershell
curl "http://localhost:5000/api/properties/neighborhoods"
```

Buscar fontes disponíveis:

```powershell
curl "http://localhost:5000/api/properties/sources"
```
