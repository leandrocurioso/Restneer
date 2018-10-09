using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Restneer.Core.Domain.Model.Entity;
using Restneer.Core.Domain.Model.ValueObject;

namespace Restneer.Core.Application.Module
{
    public interface IApiRoleModule
    {
        Task<long> Create(ApiRoleEntity apiRoleEntity);
        Task<ApiRoleEntity> Read(ApiRoleEntity apiRoleEntity);
        Task<bool> Update(ApiRoleEntity apiRoleEntity);
        Task<bool> Delete(ApiRoleEntity apiRoleEntity);
        Task<IEnumerable<ApiRoleEntity>> List(QueryParam<ApiRoleEntity> queryParam = null);
    }
}
