using System.Collections.Generic;
using System.Threading.Tasks;
using Restneer.Core.Application.Interface;
using Restneer.Core.Domain.Model.Entity;
using Restneer.Core.Domain.Model.ValueObject;

namespace Restneer.Core.Infrastructure.Repository
{
    public interface IApiResourceRouteRepository : ILister<ApiResourceRouteEntity>
    {
    }
}