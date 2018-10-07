using System;
using System.ComponentModel.DataAnnotations;

namespace Restneer.Core.Domain.Model.Entity
{
    [Serializable]
    public class ApiRoleResourceRouteEntity : AbstractEntity
    {
        [Required]
        public ApiResourceRouteEntity ApiResourceRoute { get; set; }

        [Required]
        public ApiRoleEntity ApiRole { get; set; }
    }
}
