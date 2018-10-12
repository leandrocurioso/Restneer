using System.Threading.Tasks;

namespace Restneer.Core.Application.Module
{
    public interface IUpdater<T>
    {
        Task<bool> Update(T model);
    }
}
