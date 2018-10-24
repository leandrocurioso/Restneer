using System.Threading.Tasks;

namespace Restneer.Core.Application.Interface
{
    public interface IReader<T>
    {
        Task<T> Read(T model);
    }
}
