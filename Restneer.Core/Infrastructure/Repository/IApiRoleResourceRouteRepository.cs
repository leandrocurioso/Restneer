using Restneer.Core.Domain.Model.Entity;
using Restneer.Core.Infrastructure.Interface;

namespace Restneer.Core.Infrastructure.Repository
{
    public interface IApiRoleResourceRouteRepository : ILister<ApiRoleResourceRouteEntity>,
                                                       IRepository<IApiRoleResourceRouteRepository>
    {
    }
}