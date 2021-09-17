using Microsoft.EntityFrameworkCore;
using ReservationSystem.Domain.Entity;
using ReservationSystem.Infrastructure.Interface;
using ReservationSystem.Infrastructure.Repository.Base;
using System.Threading.Tasks;

namespace ReservationSystem.Infrastructure.Repository
{
    public class UsersRepository : Repository<User>, IUsersRepository
    {
        
        public UsersRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> Authenticate(string userName, string password)
        {
            try
            {
                return await _dbContext.Users.FirstOrDefaultAsync(u => 
                u.UserName == userName && 
                u.Password == password &&
                u.DateFrom <= System.DateTime.Now.Date &&
                (u.DateTo >= System.DateTime.Now.Date || u.DateTo == null));
            }
            catch (System.Exception e)
            {

                throw;
            }
            
        }
    }
}
