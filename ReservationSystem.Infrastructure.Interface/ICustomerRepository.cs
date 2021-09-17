using ReservationSystem.Domain.Entity;
using ReservationSystem.Infrastructure.Interface.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReservationSystem.Infrastructure.Interface
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<List<Customer>> GetAllWithDocumentType();
    }
}
