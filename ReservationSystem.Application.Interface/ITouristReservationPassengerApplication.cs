using ReservationSystem.Application.DTO;
using ReservationSystem.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Application.Interface
{
    public interface ITouristReservationPassengerApplication
    {
        Task<Response<bool>> Add(ReservationPassengerDto touristReservationPassengerDto);
        Task<Response<bool>> Update(ReservationPassengerDto touristReservationPassengerDto);
        Task<Response<bool>> Delete(int Id);
        Task<Response<ReservationPassengerDto>> Get(int Id);
        Task<Response<IEnumerable<ReservationPassengerDto>>> GetAll();
        Task<Response<IEnumerable<ReservationPassengerDto>>> GetByReservationId(int reservationId);

    }  
}
