using System.Data;
using Restneer.Core.Domain.Logic;
using Restneer.Core.Domain.UseCase;
using Restneer.Core.Infrastructure.Connection;
using Restneer.Core.Infrastructure.Connection.MySql;
using Restneer.Core.Infrastructure.Connection.Redis;
using Restneer.Core.Infrastructure.Repository;
using Restneer.Core.Infrastructure.ResultFlow;
using Restneer.Core.Infrastructure.Service;
using Restneer.Core.Infrastructure.Utility;
using SimpleInjector;
using StackExchange.Redis;

namespace Restneer.Core
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
                RegisterLogic(container);
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
                container.Register<IRedisConnectionFactory, RedisConnectionFactory>(Lifestyle.Singleton);
                container.Register<IResultFlowFactory, ResultFlowFactory>(Lifestyle.Singleton);
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
                container.Register<IDbConnection>(() => container.GetInstance<ISqlConnectionFactory>().Fabricate(), Lifestyle.Scoped);
                container.Register<IDatabase>(() => container.GetInstance<IRedisConnectionFactory>().Fabricate(), Lifestyle.Scoped);
                container.Register<IRestneerCacheService, RestneerCacheService>(Lifestyle.Scoped);
                container.Register<ISha256Utility, Sha256Utility>(Lifestyle.Singleton);
                container.Register<IJwtUtility, JwtUtility>(Lifestyle.Singleton);
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

        static void RegisterLogic(Container container)
        {
            try
            {
                container.Register<IApiResourceRouteLogic, ApiResourceRouteLogic>(Lifestyle.Scoped);
                container.Register<IApiRoleResourceRouteLogic, ApiRoleResourceRouteLogic>(Lifestyle.Scoped);
                container.Register<IApiUserLogic, ApiUserLogic>(Lifestyle.Scoped);
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
