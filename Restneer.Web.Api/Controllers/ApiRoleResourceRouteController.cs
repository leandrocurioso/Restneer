using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restneer.Core.Application.UseCase.ApiRoleResourceRoute;
using Restneer.Core.Domain.Model.Entity;
using Restneer.Core.Domain.Model.ValueObject;

namespace Restneer.Web.Api.Controllers
{

    [Route("api/api-role-resource-route")]
    [ApiController]
    [Produces("application/json")]
    public class ApiRoleController : ControllerBase
    {
        readonly IApiRoleResourceRouteUseCase _apiRoleResourceRouteUseCase;

        public ApiRoleController(IApiRoleResourceRouteUseCase apiRoleResourceRouteUseCase)
        {
            _apiRoleResourceRouteUseCase = apiRoleResourceRouteUseCase;
        }

        // GET api/api-role-resource-route
        [HttpGet]
        public async Task<IEnumerable<ApiRoleResourceRouteEntity>> Get()
        {
            var queryParam = new QueryParamValueObject<ApiRoleResourceRouteEntity>();
            return await _apiRoleResourceRouteUseCase.List(queryParam);
        }
    }
}
