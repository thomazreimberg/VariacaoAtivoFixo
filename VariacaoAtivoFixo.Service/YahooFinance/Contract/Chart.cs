namespace VariacaoAtivoFixo.Services.YahooFinance.Contract
{
    public class Chart
    {
        public required List<Result> Result { get; set; }
        public required object Error { get; set; }
    }
}
