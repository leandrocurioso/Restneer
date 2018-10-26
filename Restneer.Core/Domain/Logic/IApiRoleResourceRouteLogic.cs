using Restneer.Core.Application.Interface;
using Restneer.Core.Domain.Model.Entity;

namespace Restneer.Core.Domain.Logic
{
    public interface IApiRoleResourceRouteLogic : ILister<ApiRoleResourceRouteEntity>,
                                                  ILogic<IApiRoleResourceRouteLogic>
    {
    }
}