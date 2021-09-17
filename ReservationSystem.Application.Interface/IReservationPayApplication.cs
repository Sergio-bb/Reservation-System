using ReservationSystem.Application.DTO;
using ReservationSystem.Transversal.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReservationSystem.Application.Interface
{
    public interface IReservationPayApplication
    {
        Task<Response<ReservationPayDto>> Add(ReservationPayDto reservationPayDto);       
        Task<Response<ReservationPayGetDto>> Get(int id);
        Task<Response<IEnumerable<ReservationPayGetDto>>> GetAll();
        Task<Response<IEnumerable<ReservationPayGetDto>>> GetByReservationId(int reservationId);

    }  
}
