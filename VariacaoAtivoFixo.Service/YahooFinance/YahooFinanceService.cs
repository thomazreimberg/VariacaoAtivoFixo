using RestSharp;
using VariacaoAtivoFixo.Services.YahooFinance.Contract;

namespace VariacaoAtivoFixo.Services.YahooFinance
{
    public class YahooFinanceService
    {
        private string BaseUrl { get; set; }
        public YahooFinanceService(string Url)
        {
            BaseUrl = Url;
        }

        public async Task<YahooFinanceData> GetYahooFinance(string paper)
        {
            using (var client = new RestClient(BaseUrl + paper))
            {
                var request = new RestRequest();
                var response = await client.GetAsync<YahooFinanceData>(request);

                return response ?? throw new Exception("Error in call.");
            }
        }
    }
}
