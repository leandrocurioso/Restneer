using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restneer.Core.Domain.Model.Entity
{
    [Serializable]
    [Table("api_user")]
    public class ApiUserEntity : AbstractEntity
    {
        [Required]
        public ApiRoleEntity ApiRole { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
