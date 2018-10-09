using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restneer.Core.Domain.Model.Entity
{
    [Serializable]
    [Table("api_role_resource_route")]
    public class ApiRoleResourceRouteEntity : AbstractEntity
    {
        [Required]
        public ApiResourceRouteEntity ApiResourceRoute { get; set; }

        [Required]
        public ApiRoleEntity ApiRole { get; set; }
    }
}
