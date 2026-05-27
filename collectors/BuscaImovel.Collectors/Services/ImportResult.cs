namespace BuscaImovel.Collectors.Services
{
    public sealed class ImportResult
    {
        public int Collected { get; set; }
        public int Inserted { get; set; }
        public int Updated { get; set; }
        public int Skipped { get; set; }
        public List<string> Errors { get; } = new();
    }
}
