using System.Threading.Tasks;
using Restneer.Core.Infrastructure.ResultFlow;

namespace Restneer.Core.Infrastructure.Interface
{
    public interface ICreator<T>
    {
        Task<ResultFlow<long>> Create(T model);
    }
}
