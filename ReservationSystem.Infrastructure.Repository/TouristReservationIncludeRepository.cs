using Microsoft.EntityFrameworkCore;
using ReservationSystem.Domain.Entity;
using ReservationSystem.Infrastructure.Interface;
using ReservationSystem.Infrastructure.Repository.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystem.Infrastructure.Repository
{
    public class TouristReservationIncludeRepository : Repository<ReservationInclude>, ITouristReservationIncludeRepository
    {
        public TouristReservationIncludeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<ReservationInclude>> GetByReservationId(int reservationId)
        {
            return await _dbContext.TouristReservationIncludes.Where(x => x.TouristReservationId == reservationId).ToListAsync();
        }

        

         public  async Task<ReservationInclude> GetByIdIncludeAndReservationIdAsync(int includeId, int reservationId)
        {
            return await _dbContext.TouristReservationIncludes.FirstOrDefaultAsync(x => x.IncludeId == includeId && x.TouristReservationId == reservationId);
        }
       
    }
}
