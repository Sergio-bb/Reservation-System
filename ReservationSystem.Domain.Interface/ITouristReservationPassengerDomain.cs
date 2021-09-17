using ReservationSystem.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Domain.Interface
{
    public interface ITouristReservationPassengerDomain
    {
        Task<bool> Add(ReservationPassenger touristReservationPassenger);
        Task<bool> Update(ReservationPassenger touristReservationPassenger);
        Task<bool> Delete(int Id);
        Task<ReservationPassenger> Get(int Id);
        Task<List<ReservationPassenger>> GetAll();
        Task<List<ReservationPassenger>> GetByReservationId(int reservationId);


    }
}
