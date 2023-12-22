using Microsoft.Extensions.Configuration;

namespace VariacaoAtivoFixo.Domain.Utils
{
    public class AppSettings
    {
        public string YahooFinance { get; set; }

        public AppSettings(IConfiguration configuration)
        {
            YahooFinance = configuration.GetSection("Services:YahooFinance").Value ?? "";
        }
    }
}
