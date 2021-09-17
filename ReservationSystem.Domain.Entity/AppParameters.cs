using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationSystem.Domain.Entity
{
    [Table("AppParameters")]
    public class AppParameters : Base.Entity
    {
        [StringLength(10), Required]
        public string Code { get; set; }
        [StringLength(150), Required]
        public string Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [StringLength(2000), Required]
        public string Value { get; set; }

    }
}
