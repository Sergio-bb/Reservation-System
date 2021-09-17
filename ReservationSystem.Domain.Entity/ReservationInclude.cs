using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationSystem.Domain.Entity
{
    public class ReservationInclude : Base.Entity
    {
        [ForeignKey("Reservation")]        
        public int TouristReservationId { get; set; }
        public string Code { get; set; }        
        public int IncludeId { get; set; }
        public int Item { get; set; }
        public string Description { get; set; }
        public virtual Reservation Reservation { get; set; }
    }
}
