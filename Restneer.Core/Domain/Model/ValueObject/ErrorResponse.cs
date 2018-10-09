using Newtonsoft.Json;

namespace Restneer.Core.Domain.Model.ValueObject
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string Field { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
