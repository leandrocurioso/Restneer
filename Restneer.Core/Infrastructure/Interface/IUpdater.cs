using System.Threading.Tasks;
using Restneer.Core.Infrastructure.ResultFlow;

namespace Restneer.Core.Infrastructure.Interface
{
    public interface IUpdater<T>
    {
        Task<ResultFlow<bool>> Update(T model);
    }
}
