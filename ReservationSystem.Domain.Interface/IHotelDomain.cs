using ReservationSystem.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Domain.Interface
{
    public interface IHotelDomain
    {
        Task<bool> Add(Hotel hotel);
        Task<bool> Update(Hotel hotel);
        Task<bool> Delete(int id);
        Task<Hotel> Get(int id);
        Task<List<Hotel>> GetAll();
        Task<List<Hotel>> GetByDestinationId(int destinationId);
        Task<List<Hotel>> GetAllWintDestination();
    }
}
