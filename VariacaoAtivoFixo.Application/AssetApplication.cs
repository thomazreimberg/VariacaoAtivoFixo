using AutoMapper;
using VariacaoAtivoFixo.Application.Dto;
using VariacaoAtivoFixo.Application.Interfaces;
using VariacaoAtivoFixo.Domain.Interfaces.Entities;
using VariacaoAtivoFixo.Domain.Interfaces.Services;

namespace VariacaoAtivoFixo.Application
{
    public class AssetApplication : IAssetApplication
    {
        private readonly IAssetService _assetService;
        private readonly IMapper _mapper;

        public AssetApplication(IAssetService assetService, IMapper mapper)
        {
            _assetService = assetService;
            _mapper = mapper;
        }

        public List<AssetDtoGet> GetAssets(string paper) =>
            _mapper.Map<List<AssetDtoGet>>(_assetService.GetAssets(paper));
    }
}