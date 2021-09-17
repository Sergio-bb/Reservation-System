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
    public class AirlineRepository : Repository<Airline>, IAirlineRepository 
    {
        public AirlineRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
       
    }
}
