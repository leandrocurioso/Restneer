using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
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
            }

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = 403;
            await httpContext.Response.WriteAsync(new ErrorResponseValueObject()
            {
                Message = "Invalid api key"
            }.ToString());
        }
    }
}
