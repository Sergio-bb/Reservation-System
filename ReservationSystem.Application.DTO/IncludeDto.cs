using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationSystem.Application.DTO
{
    public class IncludeDto : DtoBase
    {
        public string Code { get; set; }        
        public string Description { get; set; }
    }
}
