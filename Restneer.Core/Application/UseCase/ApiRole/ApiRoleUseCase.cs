using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Restneer.Core.Domain.Business.ApiRole;
using Restneer.Core.Domain.Model.Entity;
using Restneer.Core.Domain.Model.ValueObject;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace Restneer.Core.Application.UseCase.ApiRole
{
    public class ApiRoleUseCase : IApiRoleUseCase
    {
        readonly Container _container;

        public ApiRoleUseCase(Container container)
        {
            _container = container;
        }

        public Task<long> Create(ApiRoleEntity apiRoleEntity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(ApiRoleEntity apiRoleEntity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ApiRoleEntity>> List(QueryParam<ApiRoleEntity> queryParam = null)
        {
            try {
                using (AsyncScopedLifestyle.BeginScope(_container))
                {
                    var apiRoleBusiness = _container.GetInstance<IApiRoleBusiness>();
                    return await apiRoleBusiness.List(queryParam);
                }
            } catch {
                throw;
            }
        }

        public Task<ApiRoleEntity> Read(ApiRoleEntity apiRoleEntity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(ApiRoleEntity apiRoleEntity)
        {
            throw new NotImplementedException();
        }
    }
}
