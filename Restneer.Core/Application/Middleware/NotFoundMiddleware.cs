using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Restneer.Core.Infrastructure.Model.ValueObject;

namespace Restneer.Core.Application.Middleware
{
    public class NotFoundMiddleware : IMiddleware<NotFoundMiddleware>
    {
        public RequestDelegate Next { get; set; }
        public ILogger<NotFoundMiddleware> Logger { get; set; }
        public IConfiguration Configuration { get; set; }

        public NotFoundMiddleware(
            RequestDelegate next,
            ILogger<NotFoundMiddleware> logger,
            IConfiguration configuration
        )
        {
            Next = next;
            Logger = logger;
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
                    errors = new object[] {
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
