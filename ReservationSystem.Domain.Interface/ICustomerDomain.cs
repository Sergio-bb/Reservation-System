using ReservationSystem.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Domain.Interface
{
    public interface ICustomerDomain
    {
        Task<bool> Add(Customer customer);
        Task<bool> Update(Customer customer);
        Task<bool> Delete(int customerId);
        Task<Customer> Get(int CustomerId);
        Task<List<Customer>> GetAll();
        Task<List<Customer>> GetAllWithDocumentType();
    }
}
