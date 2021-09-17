using ReservationSystem.Application.DTO;
using ReservationSystem.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Application.Interface
{
    public interface IAccommodationRoomApplication
    {
        Task<Response<bool>> Add(AccommodationDto accommodationRoomDto);
        Task<Response<bool>> Update(AccommodationDto accommodationRoomDto);
        Task<Response<bool>> Delete(int Id);
        Task<Response<AccommodationDto>> Get(int producId);
        Task<Response<IEnumerable<AccommodationDto>>> GetAll();
    }
}
