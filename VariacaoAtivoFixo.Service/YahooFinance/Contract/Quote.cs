namespace VariacaoAtivoFixo.Services.YahooFinance.Contract
{
    public class Quote
    {
        public required List<long?> Volume { get; set; }
        public required List<double?> Close { get; set; }
        public required List<double?> High { get; set; }
        public required List<double?> Open { get; set; }
        public required List<double?> Low { get; set; }
    }
}
