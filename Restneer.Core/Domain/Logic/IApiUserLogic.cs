using System.Threading.Tasks;
using Restneer.Core.Domain.Model.Entity;
using Restneer.Core.Infrastructure.Interface;
using Restneer.Core.Infrastructure.ResultFlow;

namespace Restneer.Core.Domain.Logic
{
    public interface IApiUserLogic : ILogic<IApiUserLogic>,
                                     IReader<ApiUserEntity>
    {
        Task<ResultFlow<string>> GetJwtToken(string email, string password, string audience);
    }
}