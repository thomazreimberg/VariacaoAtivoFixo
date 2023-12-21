using AutoMapper;
using VariacaoAtivoFixo.Application.Dto;
using VariacaoAtivoFixo.Domain.Interfaces.Entities;
using VariacaoAtivoFixo.Infra.Entities;

namespace VariacaoAtivoFixo.IOC.Mappers
{
    public class AssetDtoToModelMapping : Profile
    {
        public AssetDtoToModelMapping()
        {
            Map();
        }

        private void Map()
        {
            // Add()
            CreateMap<AssetDto, IAsset>()
                .ForMember(source => source.Id, opt => opt.MapFrom(dest => dest.Id))
                .ForMember(source => source.Paper, opt => opt.MapFrom(dest => dest.Papel))
                .ForMember(source => source.Date, opt => opt.MapFrom(dest => dest.Data))
                .ForMember(source => source.Value, opt => opt.MapFrom(dest => dest.Valor))
                .ForMember(source => source.VariationFromPreviousDay, opt => opt.MapFrom(dest => dest.VariacaoDiaAnterior))
                .ForMember(source => source.VariationOnTheFirstDate, opt => opt.MapFrom(dest => dest.VariacaoPrimeiraData));

            // GetAssets()
            CreateMap<IAsset, AssetDtoGet>()
                .ForMember(source => source.Papel, opt => opt.MapFrom(dest => dest.Paper))
                .ForMember(source => source.Data, opt => opt.MapFrom(dest => dest.Date))
                .ForMember(source => source.Valor, opt => opt.MapFrom(dest => dest.Value))
                .ForMember(source => source.VariacaoDiaAnterior, opt => opt.MapFrom(dest => dest.VariationFromPreviousDay))
                .ForMember(source => source.VariacaoPrimeiraData, opt => opt.MapFrom(dest => dest.VariationOnTheFirstDate));

            CreateMap<AssetDtoGet, IAsset>()
                .ForMember(source => source.Paper, opt => opt.MapFrom(dest => dest.Papel))
                .ForMember(source => source.Date, opt => opt.MapFrom(dest => dest.Data))
                .ForMember(source => source.Value, opt => opt.MapFrom(dest => dest.Valor))
                .ForMember(source => source.VariationFromPreviousDay, opt => opt.MapFrom(dest => dest.VariacaoDiaAnterior))
                .ForMember(source => source.VariationOnTheFirstDate, opt => opt.MapFrom(dest => dest.VariacaoPrimeiraData));

            CreateMap<IAsset, Asset>()
                .ForMember(source => source.Id, opt => opt.MapFrom(dest => dest.Id))
                .ForMember(source => source.Paper, opt => opt.MapFrom(dest => dest.Paper))
                .ForMember(source => source.Date, opt => opt.MapFrom(dest => dest.Date))
                .ForMember(source => source.Value, opt => opt.MapFrom(dest => dest.Value))
                .ForMember(source => source.VariationFromPreviousDay, opt => opt.MapFrom(dest => dest.VariationFromPreviousDay))
                .ForMember(source => source.VariationOnTheFirstDate, opt => opt.MapFrom(dest => dest.VariationOnTheFirstDate));
        }
    }
}
