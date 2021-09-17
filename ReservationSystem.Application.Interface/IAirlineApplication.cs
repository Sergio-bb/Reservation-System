using ReservationSystem.Application.DTO;
using ReservationSystem.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Application.Interface
{
    public interface IAirlineApplication
    {
        Task<Response<bool>> Add(AirlineDto airlineDto);
        Task<Response<bool>> Update(AirlineDto airlineDto);
        Task<Response<bool>> Delete(int id);
        Task<Response<AirlineDto>> Get(int id);
        Task<Response<IEnumerable<AirlineDto>>> GetAll();
       
    }  
}
