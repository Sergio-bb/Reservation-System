using ReservationSystem.Domain.Entity;
using ReservationSystem.Infrastructure.Interface.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Infrastructure.Interface
{
     public interface ITouristReservationRepositoy: IRepository<Reservation>
    {
        Task<List<Reservation>> GetByCode(string Code);
        Task<List<Reservation>> GetAllUnderpayment();
    }
}
