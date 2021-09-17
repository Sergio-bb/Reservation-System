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
    public class AppParametersRepository : Repository<AppParameters>, IAppParametersRepository
    {
        public AppParametersRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
      

        public async Task<List<AppParameters>> GetByCode(string Code)
        {
            return await _dbContext.AppParameters.Where(p => p.Code.Equals(Code)).ToListAsync();
        }
    }
    
}
