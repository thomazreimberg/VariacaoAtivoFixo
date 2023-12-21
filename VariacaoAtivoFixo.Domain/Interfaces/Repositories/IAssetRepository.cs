using VariacaoAtivoFixo.Domain.Interfaces.Entities;

namespace VariacaoAtivoFixo.Domain.Interfaces.Repositories
{
    public interface IAssetRepository : IBaseRepository<IAsset>
    {
        public IQueryable<IAsset> GetAssets(string paper);
        public IAsset Add(IAsset asset);
        public void Update(IAsset asset);
    }
}
