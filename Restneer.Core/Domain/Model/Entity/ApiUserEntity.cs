using System;
using System.ComponentModel.DataAnnotations;

namespace Restneer.Core.Domain.Model.Entity
{
    [Serializable]
    public class ApiUserEntity : AbstractEntity
    {
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
