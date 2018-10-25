using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Restneer.Core.Model.ValueObject;

namespace Restneer.Core.Application.Middleware
{
    public class NotFoundMiddleware : IMiddleware
    {
        public RequestDelegate Next { get; set; }
        public IConfiguration Configuration { get; set; }

        public NotFoundMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            Next = next;
            Configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            await Next(httpContext);
            httpContext.Response.ContentType = "application/json";
            if (httpContext.Response.StatusCode == (int)HttpStatusCode.NotFound)
            {
                var errorObj = new
                {
                    errors = new object[1] {
                    new ErrorResponseValueObject() {
                        message =  "Not Found"
                    }
                }
                };
                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(errorObj));
            }
            return;
        }
    }
}
