using System.Threading.Tasks;

namespace Restneer.Core.Application.Interface
{
    public interface ICreator<T>
    {
        Task<long> Create(T model);
    }
}
