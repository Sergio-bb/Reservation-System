using ReservationSystem.Application.DTO;
using ReservationSystem.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Application.Interface
{
    public interface IHotelApplication
    {
        Task<Response<bool>> Add(HotelDto hotelDto);
        Task<Response<bool>> Update(HotelDto hotelDto);
        Task<Response<bool>> Delete(int id);
        Task<Response<HotelGetDto>> Get(int id);
        Task<Response<IEnumerable<HotelGetDto>>> GetByDestinationId(int destinationId);
        Task<Response<IEnumerable<HotelGetDto>>> GetAll();
       
    }  
}
