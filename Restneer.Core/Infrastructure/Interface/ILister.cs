using System.Collections.Generic;
using System.Threading.Tasks;
using Restneer.Core.Infrastructure.Model.ValueObject;
using Restneer.Core.Infrastructure.ResultFlow;

namespace Restneer.Core.Infrastructure.Interface
{
    public interface ILister<T>
    {
        Task<ResultFlow<IEnumerable<T>>> List(QueryParamValueObject<T> model);
    }
}
