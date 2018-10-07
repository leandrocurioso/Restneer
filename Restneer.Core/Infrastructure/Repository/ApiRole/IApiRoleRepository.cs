using System.Collections.Generic;
using System.Threading.Tasks;
using Restneer.Core.Domain.Model.Entity;

namespace Restneer.Core.Infrastructure.Repository.ApiRole
{
    public interface IApiRoleRepository
    {
        Task<long> Create(ApiRoleEntity entity = null);
        Task<IEnumerable<ApiRoleEntity>> List(ApiRoleEntity entity = null);
    }
}
