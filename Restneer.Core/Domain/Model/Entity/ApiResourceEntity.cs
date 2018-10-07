using System;
using System.ComponentModel.DataAnnotations;

namespace Restneer.Core.Domain.Model.Entity
{
    [Serializable]
    public class ApiResourceEntity : AbstractEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Uri { get; set; }
    }
}
