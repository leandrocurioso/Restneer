using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Newtonsoft.Json.Linq;
using Restneer.Core.Infrastructure.Interface;
using Restneer.Core.Infrastructure.Model.ValueObject;

namespace Restneer.Core.Infrastructure.Service
{
    public class RequestModelService<T> : IRequestModelService<T> where T : IRequestModel
    {
        readonly T _requestModel;

        public RequestModelService(T requestModel)
        {
            _requestModel = requestModel;
        }

        void PrepareFormErrorResponse()
        {
            _requestModel.ResponseErrors = new List<FormErrorResponseValueObject>();
            try
            {
                foreach (var validationResult in _requestModel.ValidationResults)
                {
                    string[] memberNames = validationResult.MemberNames.Cast<string>().ToArray();
                    _requestModel.ResponseErrors.Add(new FormErrorResponseValueObject()
                    {
                        field = memberNames[0],
                        message = validationResult.ErrorMessage,
                    });
                }
            }
            catch
            {
                throw;
            }
        }

        void TryValidateObject()
        {
            try
            {
                _requestModel.ValidationResults = new List<ValidationResult>();
                var validationContext = new ValidationContext(_requestModel, null, null);
                _requestModel.IsValid = Validator.TryValidateObject(_requestModel, validationContext, _requestModel.ValidationResults, true);
                if (!_requestModel.IsValid)
                {
                    PrepareFormErrorResponse();
                }
            }
            catch
            {
                throw;
            }
        }

        public T Validate(JObject data)
        {
            try
            {
                _requestModel.Map(data);
                TryValidateObject();
                return _requestModel;
            }
            catch
            {
                throw;
            }
        }
    }
}
