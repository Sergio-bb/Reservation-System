using ReservationSystem.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Domain.Interface
{
    public interface ITouristReservationDomain
    {
        Task<Reservation> Add(Reservation touristReservation);
        Task<bool> Update(Reservation touristReservation);
        Task<bool> Delete(int touristReservationId);
        Task<Reservation> Get(int touristReservationId);
        Task<List<Reservation>> GetAll();
        Task<List<Reservation>> GetAllUnderpayment();
        Task<IEnumerable<Reservation>> GetByCode(string code);
  
    }
}
