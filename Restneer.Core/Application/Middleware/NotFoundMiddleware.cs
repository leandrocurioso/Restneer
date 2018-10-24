using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Restneer.Core.Model.ValueObject;

namespace Restneer.Core.Application.Middleware
{
    public class NotFoundMiddleware
    {
        readonly RequestDelegate _next;

        public NotFoundMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            await _next(httpContext);
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
