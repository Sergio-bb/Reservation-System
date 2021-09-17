using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationSystem.Domain.Entity
{
    [Table("Airline")]
    public class Airline : Base.Entity
    {
        public string Name { get; set; }
        //public virtual IEnumerable<Reservation> Reservation { set; get; }
    }
}
