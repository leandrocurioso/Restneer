using System;
using Microsoft.Extensions.Configuration;

namespace Restneer.Core.Application.UseCase
{
    public abstract class AbstractUseCase
    {
        protected readonly IConfiguration _configuration;

        public AbstractUseCase(IConfiguration configuration)
        {
            _configuration = configuration;
        }
    }
}
