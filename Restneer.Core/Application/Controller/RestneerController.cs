using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Restneer.Core.Application.CustomException;
using Restneer.Core.Application.Interface;
using Restneer.Core.Application.Service;

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

        protected object Respond(HttpStatusCode httpStatusCode, object payload = null)
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

        protected object RespondRequestError(HttpStatusCode httpStatusCode, IEnumerable<object> errors)
        {
            try
            {
                HttpContext.Response.StatusCode = (int) httpStatusCode;
                return new { errors };
            }
            catch
            {
                throw;
            }
        }
    }
}
