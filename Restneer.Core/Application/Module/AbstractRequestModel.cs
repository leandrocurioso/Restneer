using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Linq;

namespace Restneer.Core.Application.Module
{
    public abstract class AbstractRequestModel
    {
        public bool IsValid { get; set; }
        public List<ValidationResult> ValidationResults = new List<ValidationResult>();
    }
}
