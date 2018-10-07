using System;
using System.ComponentModel.DataAnnotations;

namespace Restneer.Core.Domain.Model.Entity
{
    [Serializable]
    public class ApiResourceRouteEntity : AbstractEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string UriRegex { get; set; }
    }
}
