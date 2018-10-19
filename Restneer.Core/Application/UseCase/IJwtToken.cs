using System.Threading.Tasks;

namespace Restneer.Core.Application.UseCase
{
    public interface IJwtToken
    {
        Task<string> GetJwtToken(string email, string password);
    }
}
