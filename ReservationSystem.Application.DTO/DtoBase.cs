using System;
using System.Text.Json.Serialization;

namespace ReservationSystem.Application.DTO
{
    public class DtoBase
    {
        public int Id { get; set; }
        [JsonIgnore]
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        
        public string Updatedby { get; set; }
        [JsonIgnore]
        public DateTime? UpdatedDate { get; set; }

        public string Observation { get; set; }
    }
}