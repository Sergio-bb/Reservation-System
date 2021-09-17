using ReservationSystem.Application.DTO;
using ReservationSystem.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Application.Interface
{
    public interface ITouristReservationIncludeApplication
    {
        Task<Response<int>> Add(ReservationIncludeDto touristReservationIncludeDto);
        Task<Response<bool>> Update(ReservationIncludeDto touristReservationIncludeDto);
        Task<Response<bool>> Delete(int Id, int idReservation);
        Task<Response<ReservationIncludeDto>> Get(int id);
        Task<Response<IEnumerable<ReservationIncludeDto>>> GetAll();
        Task<Response<IEnumerable<ReservationIncludeDto>>> GetByReservationId(int id);
    }  
}
