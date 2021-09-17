using System.Text.Json.Serialization;

namespace ReservationSystem.Application.DTO
{
    public class HotelDto : DtoBase
    {
        public string Name { get; set; }
        public int DestinationId { get; set; }
    }
}
