using Newtonsoft.Json.Linq;
using Restneer.Core.Infrastructure.Interface;

namespace Restneer.Core.Infrastructure.Service
{
    public interface IRequestModelService<T> where T : IRequestModel
    {
        T Validate(JObject data);
    }
}