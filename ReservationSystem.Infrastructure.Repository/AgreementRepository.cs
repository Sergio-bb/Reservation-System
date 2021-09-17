using Microsoft.EntityFrameworkCore;
using ReservationSystem.Domain.Entity;
using ReservationSystem.Infrastructure.Interface;
using ReservationSystem.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ReservationSystem.Infrastructure.Repository
{
    public class AgreementRepository : Repository<Agreement>, IAgreementRepository
    {
               
        public AgreementRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Agreement>> GetByCode(string code)
        {
            return await _dbContext.Agreements.Where(p => p.Code.Equals(code)).ToListAsync();
        }
    }
}
