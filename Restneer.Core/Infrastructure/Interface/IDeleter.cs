using System.Threading.Tasks;
using Restneer.Core.Infrastructure.ResultFlow;

namespace Restneer.Core.Infrastructure.Interface
{
    public interface IDeleter<T>
    {
        Task<ResultFlow<bool>> Delete(T model);
    }
}
