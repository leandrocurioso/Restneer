using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restneer.Core.Domain.Model.Entity
{
    [Serializable]
    [Table("api_resource")]
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
