using Newtonsoft.Json;

namespace Restneer.Core.Model.ValueObject
{
    public class ErrorResponseValueObject
    {
        public string Message { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
