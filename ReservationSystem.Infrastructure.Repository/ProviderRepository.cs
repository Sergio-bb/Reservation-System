using Microsoft.EntityFrameworkCore;
using ReservationSystem.Domain.Entity;
using ReservationSystem.Infrastructure.Interface;
using ReservationSystem.Infrastructure.Repository.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystem.Infrastructure.Repository
{
    public class ProviderRepository : Repository<Provider>, IProviderRepository 
    {
        public ProviderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<Provider>> GetAllWithDocumentType()
        {
            var providers = await _dbContext.Providers.ToListAsync();
            var identityCards = await _dbContext.IdentityCardTypes.ToListAsync();
            foreach (var item in providers)
            {
                item.IdentityCardType = identityCards.FirstOrDefault(x => x.Id == item.IdentityCardTypeId);
            }
            return providers;
        }

    }
}
