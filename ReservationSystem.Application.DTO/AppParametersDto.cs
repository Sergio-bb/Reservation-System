using System;
using System.ComponentModel.DataAnnotations;

namespace ReservationSystem.Application.DTO
{
    public class AppParametersDto : DtoBase
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [Required]
        public string Value { get; set; }
    }
}
