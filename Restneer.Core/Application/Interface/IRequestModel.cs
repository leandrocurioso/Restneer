using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Linq;
using Restneer.Core.Model.ValueObject;

namespace Restneer.Core.Application.Interface
{
    public interface IRequestModel
    {
        bool IsValid { get; set; }
        List<ValidationResult> ValidationResults { get; set; }
        List<FormErrorResponseValueObject> ResponseErrors { get; set; }
        void Map(JObject data);
    }
}
