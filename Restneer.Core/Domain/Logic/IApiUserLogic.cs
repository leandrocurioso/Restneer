using System.Threading.Tasks;

namespace Restneer.Core.Domain.Logic
{
    public interface IApiUserLogic
    {
        Task<string> GetJwtToken(string email, string password);
    }
}