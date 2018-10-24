using System.Collections.Generic;
using System.Threading.Tasks;
using Restneer.Core.Domain.Model.ValueObject;

namespace Restneer.Core.Application.Interface
{
    public interface ILister<T>
    {
        Task<IEnumerable<T>> List(QueryParamValueObject<T> model);
    }
}
