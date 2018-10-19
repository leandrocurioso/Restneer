using System.Collections.Generic;
using Restneer.Core.Domain.Model.Entity;

namespace Restneer.Core.Application.Cache
{
    public static class RestneerCache
    {
       public static IEnumerable<ApiResourceRouteEntity> ApiResourceRoutes { get; set; }
       public static IEnumerable<ApiRoleResourceRouteEntity> ApiRoleResourceRoutes { get; set; }
    }
}
