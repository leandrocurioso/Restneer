using System.Threading.Tasks;

namespace Restneer.Core.Application.Module
{
    public interface IReader<T>
    {
        Task<T> Read(T model);
    }
}
