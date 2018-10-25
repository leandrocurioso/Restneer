using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Restneer.Core.Application.Middleware
{
    public class SecurityMiddleware : IMiddleware
    {
        public RequestDelegate Next { get; set; }
        public IConfiguration Configuration { get; set; }

        public SecurityMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            Next = next;
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

            /*httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = 403;
            await httpContext.Response.WriteAsync(new ErrorResponseValueObject()
            {
                Message = "Invalid api key"
            }.ToString());*/
        }
    }
}
