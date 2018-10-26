using Newtonsoft.Json.Linq;
using Restneer.Core.Application.Interface;

namespace Restneer.Core.Application.Service
{
    public interface IRequestModelService<T> where T : IRequestModel
    {
        T Validate(JObject data);
    }
}