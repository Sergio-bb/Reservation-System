using ReservationSystem.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Domain.Interface
{
    public interface IAccommodationDomain
    {
        Task<bool> Add(Accommodation accommodationRoom);
        Task<bool> Update(Accommodation accommodationRoom);
        Task<bool> Delete(int accommodationRoomId);
        Task<Accommodation> Get(int accommodationRoomId);
        Task<List<Accommodation>> GetAll();
    }
}
