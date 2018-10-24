using System.Collections.Generic;
using System.Threading.Tasks;
using Restneer.Core.Application.Interface;
using Restneer.Core.Domain.Model.Entity;
using Restneer.Core.Domain.Model.ValueObject;

namespace Restneer.Core.Domain.Logic
{
    public interface IApiResourceRouteLogic : ILister<ApiResourceRouteEntity>
    {
    }
}