using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using ShortenUrl.Services;
using ShortenUrl.Services.Helpers;
using ShortenUrl.Services.Helpers.Interfaces;
using ShortenUrl.Services.Infrastructure;
using ShortenUrl.Services.Infrastructure.Interfaces;
using ShortenUrl.Services.Infrastructure.Repositories;
using ShortenUrl.Services.Interfaces;
using ShortenUrl.Services.Mappings;
using System.Reflection;
using System.Web.Http;

namespace ShortenUrlWebHost.App_Start
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            var config = GlobalConfiguration.Configuration;

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<DbContextProvider>().AsSelf().As<IDbContextProvider>().InstancePerRequest();
            builder.RegisterType<ShortenUrlRepository>().As<IShortenUrlRepository>().InstancePerRequest();
            builder.RegisterType<ShortenUrlService>().As<IShortenUrlService>().InstancePerRequest();
            builder.RegisterType<ValidationHelper>().As<IValidationHelper>().InstancePerRequest();

            builder.Register(ctx => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DomainVsDtoMappingProfile>();
                cfg.AddProfile<DataEntityVsDomainMappingProfile>();
            }));

            builder.Register(ctx => ctx.Resolve<MapperConfiguration>().CreateMapper()).As<IMapper>();

            builder.RegisterWebApiFilterProvider(config);

            builder.RegisterWebApiModelBinderProvider();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}