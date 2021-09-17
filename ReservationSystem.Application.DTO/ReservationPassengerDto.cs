using System;

namespace ReservationSystem.Application.DTO
{
    public class ReservationPassengerDto : DtoBase
    {
        public int TouristReservationId { get; set; }
        public string IdentificationNumber { get; set; }
        public string Name { get; set; }
        public DateTime DateBirth { get; set; }
        public int Age { get; set; }        
    }
}
