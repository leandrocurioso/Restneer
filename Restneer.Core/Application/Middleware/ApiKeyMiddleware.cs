using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Restneer.Core.Infrastructure.Model.ValueObject;

namespace Restneer.Core.Application.Middleware
{
    public class ApiKeyMiddleware : IMiddleware<ApiKeyMiddleware>
    {
        public RequestDelegate Next { get; set; }
        public ILogger<ApiKeyMiddleware> Logger { get; set; }
        public IConfiguration Configuration { get; set; }

        public ApiKeyMiddleware(
            RequestDelegate next,
            ILogger<ApiKeyMiddleware> logger,
            IConfiguration configuration
        )
        {
            Next = next;
            Logger = logger;
            Configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            var requestApiKey = httpContext.Request.Headers["Api-Key"];
            var validApiKey = Configuration.GetSection("Server:ApiKey").Value;

            if (requestApiKey == validApiKey) 
            {
                await Next(httpContext);
                return;
            }

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            var errorObj = new { 
                errors = new object[] {
                    new ErrorResponseValueObject() {
                        message = "Invalid api key"
                    }
                }
            };
            await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(errorObj));
            return;
        }
    }
}
