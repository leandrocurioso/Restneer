using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Restneer.Core.Application.Controller;
using Restneer.Core.Application.Service;
using Restneer.Core.Application.UseCase;
using Restneer.Web.Api.RequestModel.V1.ApiUser;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace Restneer.Web.Api.Controllers
{
    [ApiController]
    [Route("v1/api-user")]
    [Produces("application/json")]
    public class ApiUserV1Controller : RestneerController
    {
        readonly Container _container;

        public ApiUserV1Controller(Container container)
        {
            _container = container;
        }

        [HttpPost("authenticate")]
        public async Task<object> Authenticate([FromBody] JObject body)
        {
            try
            {
                var requestModel = ValidateRequest<AuthenticateRequestModel>(body);
                if (!requestModel.IsValid)
                {
                    return RespondError(400, requestModel.ResponseErrors);
                }

                using (AsyncScopedLifestyle.BeginScope(_container))
                {
                    var apiUserUseCase = _container.GetInstance<IApiUserUseCase>();
                    var jwtToken = await apiUserUseCase.Authenticate(requestModel.email, requestModel.password);
                    HttpContext.Response.StatusCode = 200;
                    return new { token = jwtToken };
                }
            }
            catch (Exception ex)
            {
                throw ThrowError(ex, HttpStatusCode.Forbidden);
            }
        }
    }
}
