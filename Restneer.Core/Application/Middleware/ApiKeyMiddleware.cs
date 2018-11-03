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
        public ILogger<ApiKeyMiddleware> Logger { get; set; }
        public IConfiguration Configuration { get; set; }

        public ApiKeyMiddleware(
            ILogger<ApiKeyMiddleware> logger,
            IConfiguration configuration
        )
        {
            Logger = logger;
            Configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var requestApiKey = context.Request.Headers["Api-Key"];
            var validApiKey = Configuration.GetSection("Server:ApiKey").Value;

            if (requestApiKey == validApiKey) 
            {
                await next(context);
                return;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            var errorObj = new { 
                errors = new object[] {
                    new ErrorResponseValueObject() {
                        message = "Invalid api key"
                    }
                }
            };
            await context.Response.WriteAsync(JsonConvert.SerializeObject(errorObj));
            return;
        }
    }
}
