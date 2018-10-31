using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Restneer.Core.Application.Middleware
{
    public class SecurityMiddleware : IMiddleware<SecurityMiddleware>
    {
        public RequestDelegate Next { get; set; }
        public ILogger<SecurityMiddleware> Logger { get; set; }
        public IConfiguration Configuration { get; set; }

        public SecurityMiddleware(
            RequestDelegate next,
            ILogger<SecurityMiddleware> logger,
            IConfiguration configuration
        )
        {
            Next = next;
            Logger = logger;
            Configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            List<string> cleanedUrls = new List<string>();
            foreach (var uriPart in httpContext.Request.Path.Value.Split("/"))
            {
                if (uriPart != string.Empty) {
                    cleanedUrls.Add(uriPart);
                }
            }

            await Next(httpContext);
            return;
            /*httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = 403;
            await httpContext.Response.WriteAsync(new ErrorResponseValueObject()
            {
                Message = "Invalid api key"
            }.ToString());*/
        }
    }
}
