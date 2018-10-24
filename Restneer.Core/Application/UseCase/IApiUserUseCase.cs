using System.Threading.Tasks;

namespace Restneer.Core.Application.UseCase
{
    public interface IApiUserUseCase
    {
        Task<string> Authenticate(string email, string password);
    }
}