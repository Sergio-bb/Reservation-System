using ReservationSystem.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Domain.Interface
{
    public interface IAirlineDomain
    {
        Task<bool> Add(Airline airline);
        Task<bool> Update(Airline airline);
        Task<bool> Delete(int id);
        Task<Airline> Get(int id);
        Task<List<Airline>> GetAll();
       
    }
}
