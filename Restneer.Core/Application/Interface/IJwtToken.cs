using System.Threading.Tasks;

namespace Restneer.Core.Application.Interface
{
    public interface IJwtToken
    {
        Task<string> GetJwtToken(string email, string password);
    }
}
