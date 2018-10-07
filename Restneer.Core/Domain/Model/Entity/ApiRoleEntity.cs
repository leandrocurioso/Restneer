using System;
using System.ComponentModel.DataAnnotations;

namespace Restneer.Core.Domain.Model.Entity
{
	[Serializable]
    public class ApiRoleEntity : AbstractEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
