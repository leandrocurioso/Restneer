using System.Collections.Generic;
using System.Threading.Tasks;
using Restneer.Core.Domain.Model.Entity;

namespace Restneer.Core.Infrastructure.Service
{
    public interface IRestneerCacheService
    {
        Task Load();
        IEnumerable<ApiResourceRouteEntity> GetApiResourceRoute();
    }
}