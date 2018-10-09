using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Restneer.Core.Domain.Model.Entity;
using Restneer.Core.Domain.Model.ValueObject;
using Restneer.Core.Infrastructure.Repository.ApiRole;

namespace Restneer.Core.Domain.Business.ApiRole
{
    public class ApiRoleBusiness : IApiRoleBusiness
    {
        readonly IApiRoleRepository _apiRoleRepository;

        public ApiRoleBusiness(IApiRoleRepository apiRoleRepository)
        {
            _apiRoleRepository = apiRoleRepository;
        }

        public Task<long> Create(ApiRoleEntity apiRoleEntity)
        {
            throw new NotImplementedException();
        }

        public Task<ApiRoleEntity> Read(ApiRoleEntity apiRoleEntity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(ApiRoleEntity apiRoleEntity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(ApiRoleEntity apiRoleEntity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ApiRoleEntity>> List(QueryParam<ApiRoleEntity> queryParam = null)
        {
            try
            {
                return await _apiRoleRepository.List(queryParam);
            }
            catch
            {
                throw;
            }
        }
    }
}
