using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ReservationSystem.Application.DTO
{
    public class CustomerDto :DtoBase
    {
        public int IdentityCardTypeId { get; set; }

        [Required]
        public string IdentityCarNumber { get; set; }

        [Required]
        public string Name { get; set; }

        public string NickName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }

        public int Age { get => DateTime.Today.AddTicks(-DateOfBirth.Value.Ticks).Year - 1; }
    }
}
