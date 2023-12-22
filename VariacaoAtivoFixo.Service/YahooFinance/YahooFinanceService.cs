using RestSharp;
using VariacaoAtivoFixo.Services.YahooFinance.Contract;

namespace VariacaoAtivoFixo.Services.YahooFinance
{
    public class YahooFinanceService
    {
        public string BaseUrl { get; set; }
        public IRestClientWrapper? Client { get; set; }
        public YahooFinanceService(string Url)
        {
            BaseUrl = Url;
        }

        public YahooFinanceService(IRestClientWrapper? clientWrapper = null, string Url = "")
        {
            Client = clientWrapper;
            BaseUrl = Url;
        }

        public async Task<YahooFinanceData> GetYahooFinance(string paper)
        {

            if (Client is not null)
            {
                var response = await Client.GetAsync<YahooFinanceData>(paper);

                return response ?? throw new Exception("Error in call.");
            }

            using (var client = new RestClient(BaseUrl + paper))
            {
                var request = new RestRequest();
                var response = await client.GetAsync<YahooFinanceData>(request);

                return response ?? throw new Exception("Error in call.");
            }
        }
    }

    public interface IRestClientWrapper
    {
        Task<T> GetAsync<T>(string resource);
    }

    public class RestClientWrapper : IRestClientWrapper
    {
        private readonly IRestClient _client;

        public RestClientWrapper(string baseUrl)
        {
            _client = new RestClient(baseUrl);
        }

        public async Task<T> GetAsync<T>(string resource)
        {
            var request = new RestRequest(resource);
            return await _client.GetAsync<T>(request);
        }
    }
}
