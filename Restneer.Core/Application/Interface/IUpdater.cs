using System.Threading.Tasks;

namespace Restneer.Core.Application.Interface
{
    public interface IUpdater<T>
    {
        Task<bool> Update(T model);
    }
}
