using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Restneer.Core.Application.UseCase.ApiUser;
using Restneer.Web.Api.RequestModel.V1.ApiUser;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace Restneer.Web.Api.Controllers
{
    [ApiController]
    [Route("v1/api-user")]
    [Produces("application/json")]
    public class ApiUserV1Controller : ControllerBase
    {
        readonly Container _container;

        public ApiUserV1Controller(Container container)
        {
            _container = container;
        }

        // URI: /authenticate
        [HttpPost("authenticate")]
        public async Task<object> Authenticate([FromBody] JObject body)
        {
            try {
                var authenticateRequestModel = new AuthenticateRequestModel().Validate(body);
                using (AsyncScopedLifestyle.BeginScope(_container))
                {
                    var apiUserUseCase = _container.GetInstance<ApiUserUseCase>();
                    var jwtToken = await apiUserUseCase.GetJwtToken(authenticateRequestModel.Email, authenticateRequestModel.Password);
                    HttpContext.Response.StatusCode = 200;
                    return new { Token = jwtToken };
                }
            } catch {
                throw;
            }
        }
    }
}
