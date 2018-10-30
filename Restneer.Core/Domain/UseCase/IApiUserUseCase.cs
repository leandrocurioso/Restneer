using System.Threading.Tasks;
using Restneer.Core.Infrastructure.ResultFlow;

namespace Restneer.Core.Domain.UseCase
{
    public interface IApiUserUseCase : IUseCase<IApiUserUseCase>
    {
        Task<ResultFlow<string>> Authenticate(string email, string password);
    }
}