namespace VariacaoAtivoFixo.Services.YahooFinance.Contract
{
    public class Meta
    {
        public required string Currency { get; set; }
        public required string Symbol { get; set; }
        // ... outros campos
        public required CurrentTradingPeriod CurrentTradingPeriod { get; set; }
        public required List<List<TradingPeriod>> TradingPeriods { get; set; }
        public required List<string> ValidRanges { get; set; }
    }
}
