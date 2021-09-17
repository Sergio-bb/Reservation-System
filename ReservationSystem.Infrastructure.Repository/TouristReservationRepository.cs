using Microsoft.EntityFrameworkCore;
using ReservationSystem.Domain.Entity;
using ReservationSystem.Infrastructure.Interface;
using ReservationSystem.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Infrastructure.Repository
{
    public class TouristReservationRepository : Repository<Reservation>, ITouristReservationRepositoy
    {
        public TouristReservationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Reservation>> GetAllUnderpayment()
        {
            return await _dbContext.TouristReservations.Where(p => p.BalancePendientToPay > 0).ToListAsync();
        }

        public async Task<List<Reservation>> GetByCode(string code)
        {
            return await _dbContext.TouristReservations.Where(p => p.Code.Equals(code)).ToListAsync();
        }
    }
}
    