using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationSystem.Domain.Entity
{
    public class ReservationPay : Base.Entity
    {
        [ForeignKey("Reservation")]
        public int ReservationId { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }
        public virtual Reservation Reservation { get; set; }
    }
}
