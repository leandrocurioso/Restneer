using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Restneer.Core.Model.ValueObject;

namespace Restneer.Core.Application.Middleware
{
    public class ApiKeyMiddleware : IMiddleware
    {
        public RequestDelegate Next { get; set; }
        public IConfiguration Configuration { get; set; }

        public ApiKeyMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            Next = next;
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
