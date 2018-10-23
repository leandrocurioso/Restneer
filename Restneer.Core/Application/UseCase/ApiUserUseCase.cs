using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Restneer.Core.Domain.Logic;

namespace Restneer.Core.Application.UseCase.ApiUser
{
    public class ApiUserUseCase : AbstractUseCase
    {
        readonly ApiUserLogic _apiUserLogic;

        public ApiUserUseCase(ApiUserLogic apiUserLogic, IConfiguration configuration)
            :base(configuration)
        {
            _apiUserLogic = apiUserLogic;
        }

        public virtual async Task<string> GetJwtToken(string email, string password)
        {
            try {
                return await _apiUserLogic.GetJwtToken(email, password);
            } catch {
                throw;
            }
        }
    }
}
