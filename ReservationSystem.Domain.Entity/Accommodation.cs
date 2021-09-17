using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationSystem.Domain.Entity
{
    [Table("Accommodation")]
    public class Accommodation : Base.Entity
    {
        public string Code { get; set; }
        public string Description { get; set; }
        //public virtual IEnumerable<Reservation> Reservation { set; get; }

    }
}
