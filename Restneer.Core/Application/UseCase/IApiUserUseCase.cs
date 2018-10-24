using System.Threading.Tasks;

namespace Restneer.Core.Application.UseCase
{
    public interface IApiUserUseCase
    {
        Task<string> GetJwtToken(string email, string password);
    }
}