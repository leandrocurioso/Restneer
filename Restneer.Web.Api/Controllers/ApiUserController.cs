using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restneer.Core.Application.UseCase.ApiUser;
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

        // URI: /v1/api-user
        [HttpPost]
        public async Task<string> Get()
        {
            try {
                using (AsyncScopedLifestyle.BeginScope(_container))
                {
                    var apiUserUseCase = _container.GetInstance<IApiUserUseCase>();
                    var jwtToken = await apiUserUseCase.GetJwtToken("leandro.curioso@gmail.com", "5221684");
                    HttpContext.Response.Headers["Authorization"] = "Bearer " + jwtToken;
                    HttpContext.Response.StatusCode = 204;
                    return string.Empty;
                }
            } catch {
                throw;
            }
        }
    }
}
