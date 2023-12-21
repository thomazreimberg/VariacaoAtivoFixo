using VariacaoAtivoFixo.Domain.Interfaces.Entities;

namespace VariacaoAtivoFixo.Domain.Interfaces.Services
{
    public interface IAssetService
    {
        public List<IAsset> GetAssets(string paper);
    }
}
