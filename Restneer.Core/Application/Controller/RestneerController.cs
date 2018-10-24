using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Restneer.Core.Application.Interface;
using Restneer.Core.Application.Service;

namespace Restneer.Core.Application.Controller
{
    public class RestneerController : ControllerBase
    {
        protected T ValidateRequest<T>(JObject body) where T : IRequestModel
        {
            try {
                var requestModel = (T) Activator.CreateInstance(typeof(T));
                var requestModelService = new RequestModelService<T>(requestModel);
                return requestModelService.Validate(body);
            } catch {
                throw;
            }
        }

        protected object RespondError(int statusCode, IEnumerable<object> errors)
        {
            try
            {
                HttpContext.Response.StatusCode = statusCode;
                return new { errors };
            }
            catch
            {
                throw;
            }
        }
    }
}
