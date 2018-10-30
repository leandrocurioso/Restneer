using System.Threading.Tasks;
using Restneer.Core.Infrastructure.ResultFlow;

namespace Restneer.Core.Infrastructure.Interface
{
    public interface IReader<T>
    {
        Task<ResultFlow<T>> Read(T model);
    }
}
