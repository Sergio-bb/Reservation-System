using ReservationSystem.Domain.Entity;
using ReservationSystem.Infrastructure.Interface;
using ReservationSystem.Infrastructure.Repository.Base;

namespace ReservationSystem.Infrastructure.Repository
{
    public class AccommodationRepository : Repository<Accommodation>, IAccommodationRepository
    {
        public AccommodationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}