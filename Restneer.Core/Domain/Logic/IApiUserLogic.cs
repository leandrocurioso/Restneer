using System.Threading.Tasks;
using Restneer.Core.Infrastructure.ResultFlow;

namespace Restneer.Core.Domain.Logic
{
    public interface IApiUserLogic : ILogic<IApiUserLogic>
    {
        Task<ResultFlow<string>> GetJwtToken(string email, string password);
    }
}