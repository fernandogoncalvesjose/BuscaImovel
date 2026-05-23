# PRD Técnico - BuscaImovel SP

## 1. Visão Geral do Produto

BuscaImovel SP é um agregador de imóveis focado na cidade de São Paulo, que reúne ofertas de aluguel e compra em um único site. A primeira versão do MVP permite buscar e filtrar imóveis cadastrados manualmente ou via seed, com redirecionamento ao anúncio original.

## 2. Problema que Resolve

Usuários gastam muito tempo navegando em múltiplos portais imobiliários para comparar ofertas. Não há uma visão unificada e consistente para comparar custos e métricas como custo mensal total e preço por metro quadrado.

## 3. Persona Principal

- Nome: Mariana
- Idade: 32 anos
- Profissão: Analista de Marketing Digital
- Objetivo: encontrar um apartamento para alugar ou comprar em São Paulo com rapidez e clareza
- Necessidade: filtros por bairro, preço, quartos, vagas, área, aceita pet e mobiliado
- Dor: anúncios dispersos em QuintoAndar, Zap Imóveis, Viva Real, Imovelweb e OLX

## 4. Jornada do Usuário

1. Acessa a homepage do BuscaImovel SP.
2. Seleciona o tipo de negociação (aluguel ou compra).
3. Ajusta os filtros necessários.
4. Visualiza a lista de imóveis em cards.
5. Abre o detalhe de um imóvel.
6. Confere custo mensal total, preço por m² e origem.
7. Clica no link para o anúncio original.

## 5. Funcionalidades do MVP

- Página inicial com busca de imóveis.
- Filtros por:
    - tipo de negociação: aluguel ou compra
    - bairro
    - preço mínimo
    - preço máximo
    - quantidade de quartos
    - vagas
    - área mínima
    - aceita pet
    - mobiliado
- Listagem de imóveis em cards.
- Página de detalhe do imóvel.
- Link para abrir o anúncio no site original.
- Cálculo de custo mensal total (aluguel/preço + condomínio + IPTU).
- Cálculo de preço por metro quadrado.
- Origem do anúncio: QuintoAndar, Zap Imóveis, Viva Real, Imovelweb, OLX.
- Dados iniciais carregados via seed no SQLite.

## 6. Funcionalidades Fora do MVP

- Deduplicação de imóveis iguais.
- Histórico de preço.
- Score de imóvel.
- Busca por linguagem natural com IA.
- Alertas inteligentes.
- Comparador de imóveis.
- Integração com mapas.
- Dados de segurança, transporte e bairro.
- Importação automática de fontes externas.
- Painel administrativo.

## 7. Regras de Negócio

- O usuário escolhe um tipo de negociação por busca.
- O filtro de preço se aplica ao valor do aluguel ou da compra, de acordo com o tipo selecionado.
- O custo mensal total é calculado como:
    - aluguel: aluguel + condomínio + IPTU
    - compra: preço do imóvel + condomínio + IPTU (como métrica de referência)
- O preço por metro quadrado é `preço / área`.
- O imóvel só é exibido se o `linkOriginal` estiver definido.
- Imóveis com `aceitaPet` falso não são exibidos quando o filtro estiver ativo.
- Imóveis com `mobiliado` falso não são exibidos quando o filtro estiver ativo.
- Cada imóvel deve exibir origem e link para o anúncio original.
- O seed inicial deve conter pelo menos 20 imóveis com origens variadas.

## 8. Modelo de Dados Inicial

### Entidade Imovel

- `id`: GUID
- `tipoNegociacao`: enum { Aluguel, Compra }
- `titulo`: string
- `descricao`: string
- `bairro`: string
- `preco`: decimal
- `condominio`: decimal
- `iptu`: decimal
- `quartos`: int
- `vagas`: int
- `area`: decimal
- `aceitaPet`: bool
- `mobiliado`: bool
- `origem`: enum { QuintoAndar, ZapImoveis, VivaReal, Imovelweb, OLX }
- `linkOriginal`: string
- `endereco`: string
- `dataCriacao`: DateTime
- `dataAtualizacao`: DateTime

### Entidades Principais

- Imovel
- OrigemAnuncio (enum)
- FiltrosBusca (DTO)
- ResultadoImovel (DTO)
- DetalheImovel (DTO)

## 9. Endpoints da API

Base: `/api/imoveis`

- `GET /api/imoveis`
    - Retorna listagem de imóveis com filtros.
    - Query params: `tipoNegociacao`, `bairro`, `precoMin`, `precoMax`, `quartos`, `vagas`, `areaMin`, `aceitaPet`, `mobiliado`.
- `GET /api/imoveis/{id}`
    - Retorna detalhes de um imóvel.
- `GET /api/imoveis/origens`
    - Retorna origens suportadas (opcional).
- `POST /api/imoveis/seed`
    - Executa o seed inicial em ambiente de desenvolvimento.

## 10. Estrutura de Pastas Sugerida

### Backend (`backend/`)

- `BuscaImovel.Api/`
    - Controllers/
    - Models/
    - DTOs/
    - Services/
    - Data/
    - Migrations/
    - Extensions/
- `BuscaImovel.Domain/`
    - Entities/
    - Enums/
    - ValueObjects/
- `BuscaImovel.Infrastructure/`
    - Data/
    - Repositories/
    - Seed/
    - Configuration/
- `BuscaImovel.Tests/`
    - UnitTests/
    - IntegrationTests/

### Frontend (`frontend/`)

- `src/app/`
    - `page.tsx`
    - `layout.tsx`
- `src/components/`
    - `ImovelCard.tsx`
    - `ImovelFilters.tsx`
    - `ImovelDetail.tsx`
    - `SearchBar.tsx`
- `src/lib/`
    - `api.ts`
    - `types.ts`
    - `utils.ts`
- `src/styles/`
    - `globals.css`
- `public/`
- `data/` (opcional para mock local)

## 11. Critérios de Aceite

- A homepage permite buscar imóveis e aplicar todos os filtros obrigatórios.
- A listagem exibe cards com preço, bairro, quartos, vagas, área, origem e custo total.
- A página de detalhe mostra todas as informações e o link para o anúncio original.
- O custo mensal total e o preço por metro quadrado são calculados corretamente.
- O backend expõe API funcional com filtros e detalhes.
- O banco SQLite é populado por seed inicial com exemplos.
- O frontend usa Next.js, TypeScript, Tailwind CSS e shadcn/ui.
- O backend usa ASP.NET Core Web API, EF Core e SQLite.
- A aplicação está pronta para deploy em Vercel (frontend) e serviço .NET gratuito (backend).
- A documentação técnica descreve arquitetura, dados e endpoints.

## 12. Roadmap por Fases

### Fase 1 — MVP básico

- Definir domínio e modelagem.
- Criar backend ASP.NET Core + SQLite.
- Implementar seed e API de listagem/detalhes.
- Criar frontend com busca e listagem.
- Publicar em Vercel + serviço .NET gratuito.

### Fase 2 — UX e refinamento

- Adicionar paginação e ordenação.
- Melhorar cards e destacar métricas.
- Aprimorar UI/UX com shadcn/ui.
- Validar design mobile-first.

### Fase 3 — Evolução de dados

- Adicionar painel administrativo.
- Habilitar CRUD interno para imóveis.
- Preparar histórico de preços.

### Fase 4 — IA e experiências avançadas

- Implementar busca por linguagem natural com IA.
- Desenvolver score de imóvel e alertas inteligentes.
- Criar pipeline de ingestão automática de fontes externas.

## 13. Riscos Técnicos e Jurídicos

### Riscos Técnicos

- Dependência de seed manual limita a escala inicial.
- Cálculo de métricas deve tratar valores nulos ou ausentes.
- Integração futura com APIs externas terá formatos variados.
- Deploy gratuito pode impor limites de CPU, memória e tempo de execução.

### Riscos Jurídicos

- Exibir claramente que o BuscaImovel SP redireciona para anúncios de terceiros.
- Não realizar scraping automático sem autorização para evitar violação de termos de uso.
- Incluir aviso de que o site agrega dados e não é responsável pelos anúncios originais.
- Respeitar propriedade intelectual de imagens e textos dos anúncios.

## 14. Estratégia de Publicação Grátis

### Frontend

- Deploy em Vercel usando Next.js.
- Usar domínio gratuito `.vercel.app` inicialmente.
- Configurar variáveis de ambiente para URL do backend.

### Backend

- Deploy em serviço gratuito compatível com .NET, como Render, Fly.io ou Railway.
- Usar SQLite para armazenamento local ou persistente em ambiente gratuito.
- Configurar CORS para permitir chamadas do frontend.

### Observações

- Documentar deploy no README.
- Garantir conexão segura entre frontend e backend.

## 15. Próximos Prompts para Gerar o Código

1. "Crie o projeto backend ASP.NET Core Web API com Entity Framework Core e SQLite, incluindo entidade `Imovel`, migration inicial e seed data."
2. "Implemente endpoints `GET /api/imoveis` e `GET /api/imoveis/{id}` com filtros no backend."
3. "Crie o frontend Next.js com página inicial, componentes de filtro e listagem de imóveis usando Tailwind CSS e shadcn/ui."
4. "Adicione a página de detalhe de imóvel no frontend e o link para o anúncio original."
5. "Configure deploy do frontend no Vercel e do backend em um serviço .NET gratuito."
6. "Escreva testes unitários básicos para backend e e2e para a busca de imóveis no frontend."
