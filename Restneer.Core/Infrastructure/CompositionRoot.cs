using System.Data;
using Restneer.Core.Domain.Business.ApiRole;
using Restneer.Core.Infrastructure.Connection;
using Restneer.Core.Infrastructure.Connection.MySql;
using Restneer.Core.Infrastructure.Repository.ApiRole;
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
                container.Register<IApiRoleRepository, ApiRoleRepository>(Lifestyle.Scoped);
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
                container.Register<IApiRoleBusiness, ApiRoleBusiness>(Lifestyle.Scoped);
            }
            catch
            {
                throw;
            }
        }
    }
}
