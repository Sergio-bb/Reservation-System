using System;
using System.Text.Json.Serialization;

namespace ReservationSystem.Application.DTO
{
    public class ReservationPayDto : DtoBase
    {
        public int ReservationId { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }   
        [JsonIgnore]
        public ReservationGetDto Reservation { get; set; }

    }
}
