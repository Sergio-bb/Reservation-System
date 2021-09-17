using ReservationSystem.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Domain.Interface
{
    public interface IDestinationDomain
    {
        Task<bool> Add(Destination destination);
        Task<bool> Update(Destination destination);
        Task<bool> Delete(int id);
        Task<Destination> Get(int id);
        Task<List<Destination>> GetAll();
        Task<IEnumerable<Destination>> GetByCode(string code);
    }
}
