using Microsoft.EntityFrameworkCore;
using ReservationSystem.Domain.Entity;
using ReservationSystem.Infrastructure.Interface;
using ReservationSystem.Infrastructure.Interface.Base;
using ReservationSystem.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Infrastructure.Repository
{
    public class IncludeRepository : Repository<Include>, IIncludeRepositoy
    {
        public IncludeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<Include>> GetByCode(string code)
        {
            return await _dbContext.Includes.Where(p => p.Code.Equals(code)).ToListAsync();
        }
    }
}
    