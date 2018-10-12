using System.Threading.Tasks;

namespace Restneer.Core.Application.Module
{
    public interface ICreator<T>
    {
        Task<long> Create(T model);
    }
}
