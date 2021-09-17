using System.ComponentModel.DataAnnotations;

namespace ReservationSystem.Application.DTO
{
    public class DestinationDto : DtoBase
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
    }

}
