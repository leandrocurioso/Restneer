﻿using System.Threading.Tasks;
using Restneer.Core.Domain.Model.Entity;

namespace Restneer.Core.Infrastructure.Repository
{
    public interface IApiUserRepository
    {
        Task<ApiUserEntity> Authenticate(string email, string encryptedPassword);
    }
}