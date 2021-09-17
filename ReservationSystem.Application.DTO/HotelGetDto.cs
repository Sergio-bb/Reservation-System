using System.Text.Json.Serialization;

namespace ReservationSystem.Application.DTO
{
    public class HotelGetDto : DtoBase
    {
        public string Name { get; set; }
        public int DestinationId { get; set; }
        [JsonIgnore]
        public virtual DestinationDto Destination { set; get; }
        public string DestinationName { get => Destination == null ? "" : Destination.Name; }
    }
}
