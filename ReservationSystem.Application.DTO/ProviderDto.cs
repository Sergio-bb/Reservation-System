using System.Text.Json.Serialization;

namespace ReservationSystem.Application.DTO
{
    public class ProviderDto : DtoBase
    {

        public int IdentityCardTypeId { get; set; }
        public string IdentityCardNumber { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
