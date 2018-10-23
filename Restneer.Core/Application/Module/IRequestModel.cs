using Newtonsoft.Json.Linq;

namespace Restneer.Core.Application.Module
{
    public interface IRequestModel<T>
    {
        T Validate(JObject data);
    }
}
