using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Restneer.Core.Domain.Business.ApiUser;

namespace Restneer.Core.Application.UseCase.ApiUser
{
    public class ApiUserUseCase : AbstractUseCase,
                                  IApiUserUseCase
    {
        readonly IApiUserBusiness _apiUserBusiness;

        public ApiUserUseCase(IApiUserBusiness apiUserBusiness, IConfiguration configuration)
            :base(configuration)
        {
            _apiUserBusiness = apiUserBusiness;
        }

        public async Task<string> GetJwtToken(string email, string password)
        {
            try {
                return await _apiUserBusiness.GetJwtToken(email, password);
            } catch {
                throw;
            }
        }
    }
}
