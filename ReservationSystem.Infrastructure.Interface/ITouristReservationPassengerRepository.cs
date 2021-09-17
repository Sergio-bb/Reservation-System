using ReservationSystem.Domain.Entity;
using ReservationSystem.Infrastructure.Interface.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Infrastructure.Interface
{
    public interface ITouristReservationPassengerRepository : IRepository<ReservationPassenger>
    {
        Task<List<ReservationPassenger>> GetByDestinationId(int reservationId);
    }
}
