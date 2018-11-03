using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Linq;
using Restneer.Core.Infrastructure.Interface;
using Restneer.Core.Infrastructure.Model.ValueObject;

namespace Restneer.Web.Api.RequestModel.V1.ApiUser
{
    public class ReadRequestModel : IRequestModel

    {
        public bool IsValid { get; set; }
        public List<ValidationResult> ValidationResults { get; set; }
        public List<FormErrorResponseValueObject> ResponseErrors { get; set; }

        [Required]
        public long id { get; set; }

        public void Map(JObject data)
        {
            try
            {
                id = data.GetValue("id").Value<long>();
            }
            catch
            {
                throw;
            }
        }
    }
}
