using System.Threading.Tasks;

namespace Restneer.Core.Application.Module
{
    public interface IDeleter<T>
    {
        Task<bool> Delete(T model);
    }
}
