# Busca Imóvel - Backend

Este projeto faz parte da solução Busca Imóvel.
A documentação principal está em `../README.md`.

## Collector

O projeto `backend/BuscaImovel.Collectors` importa dados externos para o mesmo banco SQLite da API.

OLX collector

- Configuração: `backend/BuscaImovel.Collectors/appsettings.json` → `Collectors:Olx`
- Para ativar/desativar, altere `Enabled`.
- Ajuste `MaxPages` para aumentar a área de busca (use com cautela).

Executar o collector (usar rebuild normal requer parar a API se ela estiver rodando):

```powershell
cd backend\BuscaImovel.Collectors
dotnet restore
dotnet build /p:BuildProjectReferences=false
dotnet run
```

Para rodar com rebuild completo (quando a API não estiver em execução):

```powershell
dotnet build
dotnet run
```

O collector inclui `FakePropertyCollector` (padrão quando OLX está desabilitado) e `OlxPropertyCollector` quando `Enabled=true`.
