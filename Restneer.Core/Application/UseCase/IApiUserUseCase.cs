using System.Threading.Tasks;

namespace Restneer.Core.Application.UseCase
{
    public interface IApiUserUseCase : IUseCase<IApiUserUseCase>
    {
        Task<string> Authenticate(string email, string password);
    }
}