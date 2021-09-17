using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationSystem.Domain.Entity
{
    [Table("Destination")]
    public class Destination : Base.Entity
    {
        [StringLength(4), Required]
        public string Code { get; set; }
        [StringLength(150), Required]
        public string Name { get; set; }
        //public virtual IEnumerable<Reservation> Reservation { set; get; }
    }
}
