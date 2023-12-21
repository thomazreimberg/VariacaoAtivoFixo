namespace VariacaoAtivoFixo.Services.YahooFinance.Contract
{
    public class Result
    {
        public required Meta Meta { get; set; }
        public required List<long> TimeStamp { get; set; }
        public required Indicators Indicators { get; set; }
    }
}
