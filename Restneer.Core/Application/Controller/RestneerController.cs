using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Restneer.Core.Infrastructure.Interface;
using Restneer.Core.Infrastructure.Model.ValueObject;
using Restneer.Core.Infrastructure.ResultFlow;
using Restneer.Core.Infrastructure.Service;

namespace Restneer.Core.Application.Controller
{
    public class RestneerController<T> : ControllerBase
    {
        protected readonly ILogger<T> Logger;

        public RestneerController(ILogger<T> logger)
        {
            Logger = logger;
        }

        protected U ValidateRequest<U>(JObject body) where U : IRequestModel
        {
            try {
                var requestModel = (U) Activator.CreateInstance(typeof(U));
                var requestModelService = new RequestModelService<U>(requestModel);
                return requestModelService.Validate(body);
            } catch {
                throw;
            }
        }

        protected object RespondSuccess(HttpStatusCode httpStatusCode, object payload = null)
        {
            try
            {
                HttpContext.Response.StatusCode = (int) httpStatusCode;
                return new { payload };
            }
            catch
            {
                throw;
            }
        }

        protected object RespondError(HttpStatusCode httpStatusCode, object error)
        {
            try
            {
                HttpContext.Response.StatusCode = (int) httpStatusCode;
                if (error is IEnumerable<object>) {
                    return new { errors = error };
                } else {
                    return new { 
                        errors = new object[] {
                            new ErrorResponseValueObject() {
                                message = (string) error
                            }
                        }
                    };
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
