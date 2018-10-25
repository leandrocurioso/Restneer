using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Linq;
using Restneer.Core.Application.Interface;
using Restneer.Core.Model.ValueObject;

namespace Restneer.Web.Api.RequestModel.V1.ApiUser
{
    public class AuthenticateRequestModel : IRequestModel

    {
        public bool IsValid { get; set; }
        public List<ValidationResult> ValidationResults { get; set; }
        public List<FormErrorResponseValueObject> ResponseErrors { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(300)]
        public string email { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 6)]
        public string password { get; set; }

        public void Map(JObject data)
        {
            try
            {
                email = data.GetValue("email")?.Value<string>();
                password = data.GetValue("password")?.Value<string>();
            }
            catch
            {
                throw;
            }
        }
    }
}
