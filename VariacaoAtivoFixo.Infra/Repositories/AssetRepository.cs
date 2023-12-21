using AutoMapper;
using VariacaoAtivoFixo.Domain.Interfaces.Entities;
using VariacaoAtivoFixo.Domain.Interfaces.Repositories;
using VariacaoAtivoFixo.Infra.Context;
using VariacaoAtivoFixo.Infra.Entities;

namespace VariacaoAtivoFixo.Infra.Repositories
{
    public class AssetRepository : IAssetRepository
    {
        private readonly VariacaoAtivoFixoContext _variacaoAtivoFixoContext;
        private readonly IMapper _mapper;

        public AssetRepository(VariacaoAtivoFixoContext variacaoAtivoFixoContext, IMapper mapper)
        {
            _variacaoAtivoFixoContext = variacaoAtivoFixoContext;
            _mapper = mapper;
        }

        public IQueryable<IAsset> GetAssets(string paper) => 
            _variacaoAtivoFixoContext.Asset;

        public IAsset Add(IAsset entity)
        {
            var asset = _mapper.Map<Asset>(entity);

            _variacaoAtivoFixoContext.Add(asset);
            _variacaoAtivoFixoContext.SaveChanges();

            return asset;
        }

        public void Update(IAsset entity)
        {
            var asset = _variacaoAtivoFixoContext.Asset.Find(entity.Id) ?? throw new Exception("Asset not found.");

            asset.VariationFromPreviousDay = entity.VariationFromPreviousDay;
            asset.VariationOnTheFirstDate = entity.VariationOnTheFirstDate;

            _variacaoAtivoFixoContext.SaveChanges();
        }

        public IAsset CreateFactory()
        {
            return new Asset() { Paper = "" };
        }
    }
}