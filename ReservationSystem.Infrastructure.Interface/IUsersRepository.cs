using ReservationSystem.Domain.Entity;
using ReservationSystem.Infrastructure.Interface.Base;
using System.Threading.Tasks;

namespace ReservationSystem.Infrastructure.Interface
{
    public interface IUsersRepository : IRepository<User>
    {
        Task<User> Authenticate(string username, string password);
    }
}
