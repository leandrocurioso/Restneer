using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Restneer.Core.Domain.Model.Entity;

namespace Restneer.Core.Domain.Business.ApiRole
{
    public interface IApiRoleBusiness
    {
        Task<IEnumerable<ApiRoleEntity>> List(ApiRoleEntity entity = null);
    }
}
