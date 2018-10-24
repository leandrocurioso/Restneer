using System.Threading.Tasks;

namespace Restneer.Core.Application.Interface
{
    public interface IDeleter<T>
    {
        Task<bool> Delete(T model);
    }
}
