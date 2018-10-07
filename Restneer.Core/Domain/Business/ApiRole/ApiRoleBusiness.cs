using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Restneer.Core.Domain.Model.Entity;
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

        public async Task<IEnumerable<ApiRoleEntity>> List(ApiRoleEntity entity = null)
        {
            try {
                return await _apiRoleRepository.List(entity);
            } catch {
                throw;
            }
        }
    }
}
