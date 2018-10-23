using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Linq;
using Restneer.Core.Application.Module;

namespace Restneer.Web.Api.RequestModel.V1.ApiUser
{
    public class AuthenticateRequestModel : AbstractRequestModel,
                                            IRequestModel<AuthenticateRequestModel>
    {
        [Required]
        [EmailAddress] 
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public virtual AuthenticateRequestModel Validate(JObject data)
        {
            var authenticateRequestModel = new AuthenticateRequestModel()
            {
                Email = data.GetValue("email")?.Value<string>(),
                Password = data.GetValue("password")?.Value<string>()
            };

            var results = new List<ValidationResult>();
            var validationContext = new ValidationContext(authenticateRequestModel, null, null);
            authenticateRequestModel.IsValid = Validator.TryValidateObject(authenticateRequestModel, validationContext, authenticateRequestModel.ValidationResults, true);
            return authenticateRequestModel;
        }
    }
}
