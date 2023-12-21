using VariacaoAtivoFixo.Application.Dto;

namespace VariacaoAtivoFixo.Application.Interfaces
{
    public interface IAssetApplication
    {
        public List<AssetDtoGet> GetAssets(string paper);
    }
}
