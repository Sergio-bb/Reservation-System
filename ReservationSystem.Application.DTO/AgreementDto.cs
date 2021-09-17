using System.ComponentModel.DataAnnotations;

namespace ReservationSystem.Application.DTO
{
    public class AgreementDto : DtoBase
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        public double Rate { get; set; }
    }
}
