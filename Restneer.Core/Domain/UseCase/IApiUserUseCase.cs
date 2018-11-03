using System.Threading.Tasks;
using Restneer.Core.Domain.Model.Entity;
using Restneer.Core.Infrastructure.Interface;
using Restneer.Core.Infrastructure.ResultFlow;

namespace Restneer.Core.Domain.UseCase
{
    public interface IApiUserUseCase : IUseCase<IApiUserUseCase>,
                                       IReader<ApiUserEntity>
    {
        Task<ResultFlow<string>> Authenticate(string email, string password, string audience);
    }
}