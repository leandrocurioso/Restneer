using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Restneer.Core.Application.Controller;
using Restneer.Core.Domain.UseCase;
using Restneer.Core.Infrastructure.Service;
using Restneer.Web.Api.RequestModel.V1.ApiUser;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace Restneer.Web.Api.Controllers
{
    [ApiController]
    [Route("v1/api-user")]
    [Produces("application/json")]
    public class V1ApiUserController : RestneerController<V1ApiUserController>
    {
        readonly Container _container;

        public V1ApiUserController(Container container, ILogger<V1ApiUserController> logger)
            :base(logger)
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
                    return RespondError(HttpStatusCode.BadRequest, requestModel.ResponseErrors);
                }
                using (AsyncScopedLifestyle.BeginScope(_container))
                {
                    var apiUserUseCase = _container.GetInstance<IApiUserUseCase>();
                    var testResultFlow = await apiUserUseCase.Authenticate(requestModel.email, requestModel.password);
                    if (testResultFlow.IsSuccess())
                    {
                        return RespondSuccess(HttpStatusCode.OK, new { token = testResultFlow.Result });
                    }
                    return RespondError(HttpStatusCode.Forbidden, testResultFlow.Message );
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
