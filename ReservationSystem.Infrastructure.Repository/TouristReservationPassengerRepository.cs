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
    public class TouristReservationPassengerRepository : Repository<ReservationPassenger>, ITouristReservationPassengerRepository 
    {
        public TouristReservationPassengerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<ReservationPassenger>> GetByDestinationId(int reservationId)
        {       
            
                return await _dbContext.TouristReservationPassengers.Where(x => x.TouristReservationId == reservationId).ToListAsync();
            
        }
    }
}
