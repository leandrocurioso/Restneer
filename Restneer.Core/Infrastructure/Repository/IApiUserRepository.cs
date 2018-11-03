using System.Threading.Tasks;
using Restneer.Core.Domain.Model.Entity;
using Restneer.Core.Infrastructure.Interface;
using Restneer.Core.Infrastructure.ResultFlow;

namespace Restneer.Core.Infrastructure.Repository
{
    public interface IApiUserRepository : IRepository<IApiUserRepository>,
                                          IReader<ApiUserEntity>

    {
        Task<ResultFlow<ApiUserEntity>> Authenticate(string email, string encryptedPassword);
    }
}