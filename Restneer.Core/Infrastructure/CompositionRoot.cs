using System.Data;
using Restneer.Core.Application.Boot;
using Restneer.Core.Application.UseCase.ApiUser;
using Restneer.Core.Domain.Business.ApiResourceRoute;
using Restneer.Core.Domain.Business.ApiRoleResourceRoute;
using Restneer.Core.Domain.Business.ApiUser;
using Restneer.Core.Infrastructure.Connection;
using Restneer.Core.Infrastructure.Connection.MySql;
using Restneer.Core.Infrastructure.Repository.ApiResourceRoute;
using Restneer.Core.Infrastructure.Repository.ApiRoleResourceRoute;
using Restneer.Core.Infrastructure.Repository.ApiUser;
using Restneer.Core.Infrastructure.Utility.Sha256;
using SimpleInjector;

namespace Restneer.Core.Infrastructure
{
    public static class CompositionRoot
    {
        public static void Register(Container container)
        {
            try
            {
                RegisterFactory(container);
                RegisterGeneral(container);
                RegisterRepository(container);
                RegisterBusiness(container);
                RegisterUseCase(container);
            }
            catch
            {
                throw;
            }
        }

        static void RegisterFactory(Container container)
        {
            try
            {
                container.Register<ISqlConnectionFactory, MySqlConnectionFactory>(Lifestyle.Singleton);
            }
            catch
            {
                throw;
            }
        }

        static void RegisterGeneral(Container container)
        {
            try
            {
                container.Register<IDbConnection>(() =>
                    container.GetInstance<ISqlConnectionFactory>().Fabricate(), Lifestyle.Scoped);

                container.Register<IRestneerCacheBoot, RestneerCacheBoot>(Lifestyle.Scoped);

                container.Register<ISha256Utility, Sha256Utility>(Lifestyle.Singleton);

            }
            catch
            {
                throw;
            }
        }

        static void RegisterRepository(Container container)
        {
            try
            {
                container.Register<IApiResourceRouteRepository, ApiResourceRouteRepository>(Lifestyle.Scoped);
                container.Register<IApiRoleResourceRouteRepository, ApiRoleResourceRouteRepository>(Lifestyle.Scoped);
                container.Register<IApiUserRepository, ApiUserRepository>(Lifestyle.Scoped);

            }
            catch
            {
                throw;
            }
        }

        static void RegisterBusiness(Container container)
        {
            try
            {
                container.Register<IApiResourceRouteBusiness, ApiResourceRouteBusiness>(Lifestyle.Scoped);
                container.Register<IApiRoleResourceRouteBusiness, ApiRoleResourceRouteBusiness>(Lifestyle.Scoped);
                container.Register<IApiUserBusiness, ApiUserBusiness>(Lifestyle.Scoped);
            }
            catch
            {
                throw;
            }
        }

        static void RegisterUseCase(Container container)
        {
            try
            {
                container.Register<IApiUserUseCase, ApiUserUseCase>(Lifestyle.Scoped);
            }
            catch
            {
                throw;
            }
        }
    }
}
