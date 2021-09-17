using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationSystem.Domain.Entity
{
    public class ReservationPassenger : Base.Entity
    {
        [ForeignKey("Reservation")]
        public int TouristReservationId { get; set; }
        public string IdentificationNumber { get; set; }
        public string Name { get; set; }
        public DateTime DateBirth { get; set; }
        public int Age { get; set; }
        public virtual Reservation Reservation { get; set; }
    }
}
