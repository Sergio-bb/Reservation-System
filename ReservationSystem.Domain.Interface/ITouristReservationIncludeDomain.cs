using ReservationSystem.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Domain.Interface
{
    public interface ITouristReservationIncludeDomain
    {
        Task<int> Add(ReservationInclude touristReservationInclude);
        Task<bool> Update(ReservationInclude touristReservationInclude);
        Task<bool> Delete(int touristReservationIncludeId, int idReservation);       
        Task<ReservationInclude> Get(int touristReservationIncludeId);
        Task<List<ReservationInclude>> GetAll();       
        Task<List<ReservationInclude>> GetByReservationId(int reservationId);       
    }
}
