using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Restneer.Core.Model.ValueObject;

namespace Restneer.Core.Application.Middleware
{
    public class ApiKeyMiddleware
    {
        public IConfiguration Configuration { get; set; }
        readonly RequestDelegate _next;

        public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            Configuration = configuration;
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            var requestApiKey = httpContext.Request.Headers["Api-Key"];
            var validApiKey = Configuration.GetSection("Server:ApiKey").Value;

            if (requestApiKey == validApiKey) 
            {
                await _next(httpContext);
                return;
            }

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = 400;
            var errorObj = new { 
                errors = new object[1] {
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
