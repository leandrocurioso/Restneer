using Restneer.Core.Application.Interface;
using Restneer.Core.Domain.Model.Entity;

namespace Restneer.Core.Infrastructure.Repository
{
    public interface IApiResourceRouteRepository : ILister<ApiResourceRouteEntity>,
                                                   IRepository<IApiResourceRouteRepository>
    {
    }
}