namespace VariacaoAtivoFixo.Services.YahooFinance.Contract
{
    public class CurrentTradingPeriod
    {
        public required TradingPeriod Pre { get; set; }
        public required TradingPeriod Regular { get; set; }
        public required TradingPeriod Post { get; set; }
    }
}
