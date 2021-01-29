using System.Collections.Generic;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using AutofacAndAutomapper.Mapping;
using AutofacAndAutomapper.Services;
using AutoMapper;

namespace AutofacAndAutomapper
{
    public partial class Startup
    {
        public static void ConfigureWebApi()
        {
            GlobalConfiguration.Configure(RegisterWebApiConfiguration);
        }

        public static void ConfigureAutofac()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<MappingModule>();
            builder.RegisterType<FancyService>().As<IFancyService>();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AsClosedTypesOf(typeof(ITypeConverter<,>))
                .AsSelf()
                .InstancePerLifetimeScope();

            builder.Register(context =>
            {
                var profiles = context.Resolve<IEnumerable<Profile>>();
                var cfg = new MapperConfiguration(x =>
                {
                    foreach (var profile in profiles)
                    {
                        x.AddProfile(profile);
                    }
                });

                return cfg;
            }).SingleInstance().AutoActivate().AsSelf();

            builder.Register(context =>
            {
                var ctx = context.Resolve<IComponentContext>();
                var cfg = ctx.Resolve<MapperConfiguration>();
                return cfg.CreateMapper(t => ctx.Resolve(t));
            });

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();

            var config = GlobalConfiguration.Configuration;
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static void RegisterWebApiConfiguration(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new {id = RouteParameter.Optional});
        }
    }
}