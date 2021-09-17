using ReservationSystem.Domain.Entity;
using ReservationSystem.Infrastructure.Interface.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReservationSystem.Infrastructure.Interface
{
    public interface IReservationPayRepository : IRepository<ReservationPay>
    {
        Task<List<ReservationPay>> GetByReservationId(int reservationId);
    }
}
