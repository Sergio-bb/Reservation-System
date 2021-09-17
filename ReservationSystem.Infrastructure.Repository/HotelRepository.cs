using Microsoft.EntityFrameworkCore;
using ReservationSystem.Domain.Entity;
using ReservationSystem.Infrastructure.Interface;
using ReservationSystem.Infrastructure.Repository.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystem.Infrastructure.Repository
{
    public class HotelRepository : Repository<Hotel>, IHotelRepository 
    {
        public HotelRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Hotel>> GetByDestinationId(int destinationId)
        {
            return await _dbContext.Hotels.Where(x => x.DestinationId == destinationId).ToListAsync();
        }

        public async Task<List<Hotel>> GetAllWithDestinationAsync()
        {
            var destinations = await _dbContext.Destinations.ToListAsync();
            var hotels = await _dbContext.Hotels.ToListAsync();
            foreach (var item in hotels)
            {
                item.Destination = destinations.FirstOrDefault(x => x.Id == item.DestinationId);
            }
            return hotels;
        }
    }
}
