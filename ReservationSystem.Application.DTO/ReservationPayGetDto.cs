using System;
using System.Text.Json.Serialization;

namespace ReservationSystem.Application.DTO
{
    public class ReservationPayGetDto : DtoBase
    {
        public int ReservationId { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }
        [JsonIgnore]
        public ReservationGetDto Reservation { get; set; }
        public double BalancePendientTopay { get => Reservation.BalancePendientToPay; }
    }
}
