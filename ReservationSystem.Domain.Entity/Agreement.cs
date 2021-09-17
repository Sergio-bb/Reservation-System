using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationSystem.Domain.Entity
{
    [Table("Agreement")]
    public class Agreement : Base.Entity
    {
        [StringLength(150), Required]
        public string Code { get; set; }
        public string Name { get; set; }
        public double Rate { get; set; }

    }
}
