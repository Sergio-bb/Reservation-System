using ReservationSystem.Domain.Entity;
using ReservationSystem.Infrastructure.Interface.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReservationSystem.Infrastructure.Interface
{
    public interface ITouristReservationIncludeRepository : IRepository<ReservationInclude>
    {
        Task<List<ReservationInclude>> GetByReservationId(int reservationId);
        Task<ReservationInclude> GetByIdIncludeAndReservationIdAsync(int includeId, int reservationId);
    }
}
