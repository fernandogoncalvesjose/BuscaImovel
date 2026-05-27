# Busca Imóvel

Projeto fullstack para buscar e visualizar imóveis em São Paulo.

## Estrutura do repositório

- `backend/BuscaImovel.Api` — API ASP.NET Core com SQLite
- `frontend/busca-imovel-web` — frontend em Next.js, TypeScript e Tailwind CSS
- `docs/prd.md` — documento de requisitos do produto

## Requisitos

- .NET 8 SDK
- Node.js 20+
- Browser moderno

## Variáveis de ambiente

Para o frontend, copie o exemplo:

```powershell
copy .env.local.example .env.local
```

O frontend usa:

```env
NEXT_PUBLIC_API_URL=http://localhost:5000
```

## Backend

### Como rodar

```powershell
cd backend/BuscaImovel.Api
dotnet restore
dotnet build
dotnet run
```

A API será executada em `http://localhost:5000` por padrão.

### Collector de imóveis

O projeto `collectors/BuscaImovel.Collectors` é responsável por coletar dados externos simulados, normalizar o modelo e gravar no mesmo banco SQLite usado pela API.

```powershell
cd collectors/BuscaImovel.Collectors
dotnet restore
dotnet build
dotnet run
```

O collector usa a mesma connection string definida em `collectors/BuscaImovel.Collectors/appsettings.json`.

### Migrations

```powershell
cd backend/BuscaImovel.Api
dotnet ef migrations add AddPropertyExternalMetadata
dotnet ef database update
```

### Endpoints principais

- `GET /api/properties`
- `GET /api/properties/{id}`
- `GET /api/properties/neighborhoods`
- `GET /api/properties/sources`
- `GET /api/health`

### Swagger

Em modo de desenvolvimento, o Swagger fica disponível em:

`http://localhost:5000/swagger`

## Frontend

### Como rodar

```powershell
cd frontend/busca-imovel-web
npm install
copy .env.local.example .env.local
npm run dev
```

### Build de produção

```powershell
cd frontend/busca-imovel-web
npm run build
```

### Observações

- A aplicação do frontend consome a API via `NEXT_PUBLIC_API_URL`.
- O backend já inclui migrations e o banco SQLite local.
- Não há autenticação implementada nesta versão inicial.

## Notas

- Use o README principal na raiz para referência geral.
- Os READMEs em `backend/` e `frontend/busca-imovel-web/` são simples apontamentos para este arquivo.
