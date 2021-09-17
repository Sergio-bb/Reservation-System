using ReservationSystem.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Domain.Interface
{
    public interface IReservationPayDomain
    {
        Task<ReservationPay> Add(ReservationPay reservationPay);       
        Task<ReservationPay> Get(int id);
        Task<List<ReservationPay>> GetAll();
        Task<List<ReservationPay>> GetbyReservationId(int reservationId);
        
    }
}
