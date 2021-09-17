using ReservationSystem.Domain.Entity;
using ReservationSystem.Infrastructure.Interface.Base;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystem.Infrastructure.Interface
{
    public interface IHotelRepository : IRepository<Hotel>
    {
        Task<List<Hotel>> GetByDestinationId(int destinationId);
        Task<List<Hotel>> GetAllWithDestinationAsync();        
    }
}
