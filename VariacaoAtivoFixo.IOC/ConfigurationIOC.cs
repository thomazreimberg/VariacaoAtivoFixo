using Autofac;
using AutoMapper;
using VariacaoAtivoFixo.Application;
using VariacaoAtivoFixo.Domain.Interfaces.Repositories;
using VariacaoAtivoFixo.Domain.Services;
using VariacaoAtivoFixo.Infra.Repositories;
using VariacaoAtivoFixo.IOC.Mappers;

namespace VariacaoAtivoFixo.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region IOC
            
            #endregion

            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssetDtoToModelMapping());
            }));

            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>().InstancePerLifetimeScope();
        }
    }
}
