namespace VariacaoAtivoFixo.Services.YahooFinance.Contract
{
    public class Quote
    {
        public List<long?>? Volume { get; set; }
        public List<double?>? Close { get; set; }
        public List<double?>? High { get; set; }
        public List<double?>? Open { get; set; }
        public List<double?>? Low { get; set; }
    }
}
