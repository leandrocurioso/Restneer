using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Restneer.Core.Infrastructure.Model.ValueObject;

namespace Restneer.Core.Application.Middleware
{
    public class ExceptionMiddleware  : IMiddleware
    {
        public RequestDelegate Next { get; set; }
        public IConfiguration Configuration { get; set; }

        public ExceptionMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            Next = next;
            Configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await Next(httpContext);
                return;
            }
            catch (Exception ex)
            {
                 await HandleExceptionAsync(httpContext, ex);
                return;
            }
        }

        static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
            var errorObj = new
            {
                errors = new object[] {
                    new ErrorResponseValueObject() {
                        message = exception.Message
                    }
                }
            };
            await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(errorObj));
            return;
        }
    }
}
