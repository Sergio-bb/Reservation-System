using Microsoft.EntityFrameworkCore;
using ReservationSystem.Domain.Entity;
using ReservationSystem.Infrastructure.Interface;
using ReservationSystem.Infrastructure.Repository.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystem.Infrastructure.Repository
{
    public class ReservationPayRepository : Repository<ReservationPay>, IReservationPayRepository 
    {
        public ReservationPayRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<ReservationPay>> GetByReservationId(int reservationId)
        {
            return await _dbContext.ReservationPays.Where(x => x.ReservationId == reservationId).ToListAsync();
        }
    }
}
