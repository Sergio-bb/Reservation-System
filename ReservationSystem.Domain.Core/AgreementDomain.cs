using System;
using ReservationSystem.Domain.Entity;
using ReservationSystem.Domain.Interface;
using ReservationSystem.Infrastructure.Interface;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ReservationSystem.Domain.Core
{
    public class AgreementDomain : IAgreementDomain
    {
        private readonly IAgreementRepository _agreementRepository;
        public AgreementDomain(IAgreementRepository agreementRepository)
        {
            _agreementRepository = agreementRepository;
        }

        public async Task<bool> Add(Agreement agreement)
        {
            try
            {
                await _agreementRepository.AddAsync(agreement);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Update(Agreement agreement)
        {
            try
            {
                await _agreementRepository.UpdateAsync(agreement);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var prop = _agreementRepository.GetByIdAsync(id);
                await _agreementRepository.DeleteAsync(prop.Result);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Agreement> Get(int id)
        {
            return await _agreementRepository.GetByIdAsync(id);
        }

        public async Task<List<Agreement>> GetAll()
        {
            return await _agreementRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Agreement>> GetByCode(string code)
        {
            return await _agreementRepository.GetByCode(code);
        }

    }
}
