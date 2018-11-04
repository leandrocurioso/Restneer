using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Restneer.Core.Application.Controller;
using Restneer.Core.Domain.Model.Entity;
using Restneer.Core.Domain.UseCase;
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
            : base(logger)
        {
            _container = container;
        }

        [HttpGet("{id:long}")]
        public async Task<object> Read([FromRoute] long id)
        {
            try
            {
                var jObject = new JObject
                {
                    { "id", id }
                };
                var requestModel = ValidateRequest<ReadRequestModel>(jObject);
                if (!requestModel.IsValid)
                {
                    return RespondError(HttpStatusCode.BadRequest, requestModel.ResponseErrors);
                }
                using (AsyncScopedLifestyle.BeginScope(_container))
                {
                    var apiUserUseCase = _container.GetInstance<IApiUserUseCase>();
                    var apiUserEntity = new ApiUserEntity()
                    {
                        Id = requestModel.id
                    };
                    var readResultFlow = await apiUserUseCase.Read(apiUserEntity);
                    if (readResultFlow.IsSuccess())
                    {
                        return RespondSuccess(HttpStatusCode.OK, new { apiUser = readResultFlow.Result });
                    }
                    return RespondError(HttpStatusCode.NotFound, readResultFlow.Message);
                }
            }
            catch
            {
                throw;
            }
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
                var audience = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.Value}";
                using (AsyncScopedLifestyle.BeginScope(_container))
                {
                    var apiUserUseCase = _container.GetInstance<IApiUserUseCase>();
                    var authenticateResultFlow = await apiUserUseCase.Authenticate(requestModel.email, requestModel.password, audience);
                    if (authenticateResultFlow.IsSuccess())
                    {
                        return RespondSuccess(HttpStatusCode.OK, new { token = authenticateResultFlow.Result });
                    }
                    return RespondError(HttpStatusCode.Forbidden, authenticateResultFlow.Message );
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
