using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationSystem.Domain.Entity
{
    [Table("Hotel")]
    public class Hotel : Base.Entity
    {
        public string Name { get; set; }
        [ForeignKey("Destination")]
        public int DestinationId { get; set; }
        public virtual Destination Destination { set; get; }
        //public virtual IEnumerable<Reservation> Reservation { set; get; }
    }
}