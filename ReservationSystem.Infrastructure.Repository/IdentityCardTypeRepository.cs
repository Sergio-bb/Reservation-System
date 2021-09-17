using ReservationSystem.Domain.Entity;
using ReservationSystem.Infrastructure.Interface;
using ReservationSystem.Infrastructure.Repository.Base;


namespace ReservationSystem.Infrastructure.Repository
{
    public class IdentityCardTypeRepository : Repository<IdentityCardType>, IIdentityCardTypeRepository 
    {
        public IdentityCardTypeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
       
    }
}
