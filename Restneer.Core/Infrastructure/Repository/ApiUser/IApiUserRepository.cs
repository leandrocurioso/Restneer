using System.Threading.Tasks;
using Restneer.Core.Domain.Model.Entity;

namespace Restneer.Core.Infrastructure.Repository.ApiUser
{
    public interface IApiUserRepository
    {
        Task<ApiUserEntity> Authenticate(string email, string encryptedPassword);
    }
}
