using PanXPan.Api.Interfaces;
using PanXPan.Api.Repositories;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace PanXPan.Api
{
        public static class UnityConfig
        {
            public static void RegisterComponents()
            {
                var container = new UnityContainer();

                container.RegisterType<IDbContextFactory<PanXPanDbContext>, DbContextFactory>();
                container.RegisterType<IBookRepository, BookRepository>();

                GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            }
        }
}