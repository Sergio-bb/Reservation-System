using System;

namespace ReservationSystem.Application.DTO
{
    public class UsersDto : DtoBase
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Role { get => "Admin"; }
        public string Password { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string Token { get; set; }
    }
}