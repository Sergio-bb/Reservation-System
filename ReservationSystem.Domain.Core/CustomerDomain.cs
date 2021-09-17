using ReservationSystem.Domain.Entity;
using ReservationSystem.Domain.Interface;
using ReservationSystem.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Domain.Core
{
    public class CustomerDomain : ICustomerDomain
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerDomain(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<bool> Add(Customer customer)
        {
            try
            {
                await _customerRepository.AddAsync(customer);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int customerId)
        {
            try
            {
                var prop = _customerRepository.GetByIdAsync(customerId);
                await _customerRepository.DeleteAsync(prop.Result);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Customer> Get(int CustomerId)
        {
            return await _customerRepository.GetByIdAsync(CustomerId);
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _customerRepository.GetAllAsync();
        }

        public async Task<List<Customer>> GetAllWithDocumentType()
        {
            return await _customerRepository.GetAllWithDocumentType();
        }
        public async Task<bool> Update(Customer customer)
        {
            try
            {
                await _customerRepository.UpdateAsync(customer);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
