using System;
using System.ComponentModel.DataAnnotations;

namespace ReservationSystem.Domain.Entity.Base
{
    public abstract class Entity  : EntityBase<int>
    {
        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }
        [StringLength(50)]
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [StringLength(500)]
        [DataType(DataType.MultilineText)]
        public string Observation { get; set; }
    }
}
