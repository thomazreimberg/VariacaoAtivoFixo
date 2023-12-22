using FluentValidation;
using VariacaoAtivoFixo.Domain.Interfaces.Entities;
using VariacaoAtivoFixo.Domain.Interfaces.Repositories;
using VariacaoAtivoFixo.Domain.Interfaces.Services;
using VariacaoAtivoFixo.Domain.Utils;
using VariacaoAtivoFixo.Services.YahooFinance;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace VariacaoAtivoFixo.Domain.Services
{
    public class AssetService : IAssetService
    {
        private AssetValidator _assetValitor;
        private readonly AppSettings _appSettings;
        public readonly IAssetRepository _assetRepository;

        public AssetService(AppSettings appSettings, IAssetRepository assetRepository)
        {
            _assetValitor = new AssetValidator();
            _appSettings = appSettings;
            _assetRepository = assetRepository;
        }

        public List<IAsset> GetAssets(string paper)
        {
            int lSeed = 30;
            if (string.IsNullOrWhiteSpace(paper))
                throw new ArgumentNullException("Paper is invalid.");

            var assets = _assetRepository
                .GetAssets(paper)
                .Where(x => x.Date > DateTime.Now.Date.AddHours(-lSeed) && x.Paper == paper)
                .OrderByDescending(o => o.Date)
                .ToList();

            if (assets.Count < lSeed)
            {
                assets = GetNewAssets(paper, assets);
                assets = ProcessAssets(assets);
            }

            return assets;
        }

        private List<IAsset> GetNewAssets(string paper, List<IAsset> assets)
        {
            var yahooFinanceService = new YahooFinanceService(_appSettings.YahooFinance);
            var response = yahooFinanceService.GetYahooFinance(paper).GetAwaiter().GetResult();

            if (response is null)
                throw new Exception($"Error getting paper {paper}");

            var chartData = response.Chart.Result.FirstOrDefault() ?? throw new Exception($"No chart data found for paper {paper}");

            var newAssets = new List<IAsset>();
            foreach (var item in chartData.TimeStamp
                .Select((timeStamp, index) => new
                {
                    Date = Helper.UnixTimeStampToDateTime(timeStamp),
                    OpenValue = chartData.Indicators.Quote[0].Open[index]
                })
                //.GroupBy(data => data.Date.Date)
                //.Select(group => group.First())
                .Take(30)
                .ToList())
            {
                var assetDto = _assetRepository.CreateFactory();
                assetDto.Paper = paper;
                assetDto.Date = item.Date;
                assetDto.Value = item.OpenValue == null ? 0 : (decimal)item.OpenValue;
                assetDto.VariationFromPreviousDay = CalculateVariationFromPreviousDay(assets, assetDto.Value);
                assetDto.VariationOnTheFirstDate = CalculateVariationFromFirstDate(newAssets, assetDto.Value);

                Handler.Handler.Handle(_assetValitor.Validate(assetDto));

                newAssets.Add(_assetRepository.Add(assetDto));
            }

            // Remove duplicates by comparing Date and Paper
            newAssets = newAssets
                .GroupBy(a => new { a.Date, a.Paper })
                .Select(g => g.First())
                .ToList();
            newAssets.RemoveAll(x => x == assets);
            
            return newAssets;
        }

        private List<IAsset> ProcessAssets(List<IAsset> assetsToReprocess)
        {
            foreach (var asset in assetsToReprocess.OrderBy(o => o.Date))
            {
                asset.VariationFromPreviousDay = CalculateVariationFromPreviousDay(assetsToReprocess, asset.Value);
                asset.VariationOnTheFirstDate = CalculateVariationFromFirstDate(assetsToReprocess, asset.Value);

                _assetRepository.Update(asset);
            }

            return assetsToReprocess;
        }

        private decimal CalculateVariationFromPreviousDay(List<IAsset> assets, decimal currentValue)
        {
            if (assets is null || assets.Count <= 0) return 0;

            return (currentValue - assets[0].Value) / assets[0].Value * 100;
        }

        private decimal CalculateVariationFromFirstDate(List<IAsset> assets, decimal currentValue)
        {
            if (assets is null || assets.Count <= 0) return 0;

            return (currentValue - assets[0].Value) / assets[0].Value * 100;
        }
    }

    internal class AssetValidator : AbstractValidator<IAsset>
    {
        internal AssetValidator()
        {
            RuleFor(asset => asset.Paper).NotEmpty().NotNull();
            RuleFor(asset => asset.Date).NotEmpty().NotNull();
            //RuleFor(asset => asset.Value).Must(x => x > 0);
        }
    }
}
