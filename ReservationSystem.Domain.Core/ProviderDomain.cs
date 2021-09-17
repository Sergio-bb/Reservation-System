using ReservationSystem.Domain.Entity;
using ReservationSystem.Domain.Interface;
using ReservationSystem.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Domain.Core
{
    public class ProviderDomain : IProviderDomain
    {
        private readonly IProviderRepository _supplierRepository;
        public ProviderDomain(IProviderRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }
        public async Task<bool> Add(Provider supplier)
        {
            try
            {
                await _supplierRepository.AddAsync(supplier);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int supplierid)
        {
            try
            {
                var prop = _supplierRepository.GetByIdAsync(supplierid);
                await _supplierRepository.DeleteAsync(prop.Result);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Provider> Get(int id)
        {
            return await _supplierRepository.GetByIdAsync(id);
        }

        public async Task<List<Provider>> GetAllWithDocumentType()
        {
            return await _supplierRepository.GetAllWithDocumentType();
        }
        public async Task<List<Provider>> GetAll()
        {
            return await _supplierRepository.GetAllAsync();
        }

        public async Task<bool> Update(Provider supplier)
        {
            try
            {
                await _supplierRepository.UpdateAsync(supplier);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

    }
}
