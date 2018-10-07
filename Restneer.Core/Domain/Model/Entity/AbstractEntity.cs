using System;
using System.ComponentModel.DataAnnotations;
using Restneer.Core.Domain.Model.Enum;

namespace Restneer.Core.Domain.Model.Entity
{
    [Serializable]
    public abstract class AbstractEntity
    {
        public long Id{ get; set; }

        [Required]
        public DateTime CreatedAt = DateTime.Now;

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        [Required]
        public StatusEnum Status { get; set; }
    }
}
