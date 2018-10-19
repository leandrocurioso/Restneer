using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Restneer.Core.Domain.Business.ApiRoleResourceRoute;
using Restneer.Core.Domain.Model.Entity;
using Restneer.Core.Domain.Model.ValueObject;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace Restneer.Core.Application.UseCase.ApiRoleResourceRoute
{
    public class ApiRoleResourceRouteUseCase : IApiRoleResourceRouteUseCase
    {
        readonly Container _container;

        public ApiRoleResourceRouteUseCase(Container container)
        {
            _container = container;
        }

        public async Task<IEnumerable<ApiRoleResourceRouteEntity>> List(QueryParamValueObject<ApiRoleResourceRouteEntity> model)
        {
            try {
                using (AsyncScopedLifestyle.BeginScope(_container))
                {
                    var apiRoleResourceRouteBusiness = _container.GetInstance<IApiRoleResourceRouteBusiness>();
                    return await apiRoleResourceRouteBusiness.List(model);
                }
            } catch {
                throw;
            }
        }

    }
}
