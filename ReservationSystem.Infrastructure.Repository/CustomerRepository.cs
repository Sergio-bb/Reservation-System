using Microsoft.EntityFrameworkCore;
using ReservationSystem.Domain.Entity;
using ReservationSystem.Infrastructure.Interface;
using ReservationSystem.Infrastructure.Repository.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystem.Infrastructure.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
           
        }
        
        public async Task<List<Customer>> GetAllWithDocumentType()
        {
            var customers = await _dbContext.Customers.ToListAsync();
            var identityCards = await _dbContext.IdentityCardTypes.ToListAsync();
            foreach (var item in customers)
            {
                item.IdentityCardType = identityCards.FirstOrDefault(x => x.Id == item.IdentityCardTypeId);
            }
            return customers;
        }
    }

}
