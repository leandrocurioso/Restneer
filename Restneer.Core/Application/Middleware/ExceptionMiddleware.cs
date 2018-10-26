using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Restneer.Core.Application.CustomException;
using Restneer.Core.Model.ValueObject;

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
                if (ex is RestneerException) {
                    await HandleExceptionAsync(httpContext, (RestneerException) ex);
                } else {
                    var restneerException = new RestneerException(
                        ex.Message,
                        HttpStatusCode.InternalServerError
                    );
                    await HandleExceptionAsync(httpContext, restneerException);
                }
                return;
            }
        }

        static async Task HandleExceptionAsync(HttpContext httpContext, RestneerException restneerException)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)restneerException.HttpStatusCode;
            var errorObj = new
            {
                errors = new object[] {
                    new ErrorResponseValueObject() {
                        message = restneerException.Message
                    }
                }
            };
            await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(errorObj));
            return;
        }
    }
}
