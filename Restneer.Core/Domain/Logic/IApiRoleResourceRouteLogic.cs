using Restneer.Core.Domain.Model.Entity;
using Restneer.Core.Infrastructure.Interface;

namespace Restneer.Core.Domain.Logic
{
    public interface IApiRoleResourceRouteLogic : ILister<ApiRoleResourceRouteEntity>,
                                                  ILogic<IApiRoleResourceRouteLogic>
    {
    }
}