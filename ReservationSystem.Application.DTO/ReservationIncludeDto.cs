namespace ReservationSystem.Application.DTO
{
    public class ReservationIncludeDto : DtoBase
    {
        public int TouristReservationId { get; set; }
        public virtual string  Code { get; set; }
        public int IncludeId { get; set; }
        public int Item { get; set; }
        public string Description { get; set; }
    }
}
