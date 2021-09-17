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
    public class DestinationRepository : Repository<Destination>, IDestinationRepository
    {
        public DestinationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<Destination>> GetByCode(string code)
        {
            return await _dbContext.Destinations.Where(p => p.Code.Equals(code)).ToListAsync();
        }

    }
}
