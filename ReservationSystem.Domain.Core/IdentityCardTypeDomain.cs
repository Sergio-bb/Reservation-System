using ReservationSystem.Domain.Entity;
using ReservationSystem.Domain.Interface;
using ReservationSystem.Infrastructure.Interface;
using ReservationSystem.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Domain.Core
{
    public class IdentityCardTypeDomain : IIdentityCardTypeDomain
    {
        private readonly IIdentityCardTypeRepository _identityCardTypeRepository;
        public IdentityCardTypeDomain(IIdentityCardTypeRepository identityCardTypeRepository)
        {
            _identityCardTypeRepository = identityCardTypeRepository;
        }

       
        public async Task<List<IdentityCardType>> GetAll()
        {
            return await _identityCardTypeRepository.GetAllAsync();
        }
        
        public async Task<IdentityCardType> Get(int id)
        {
            return await _identityCardTypeRepository.GetByIdAsync(id);
        }
    }
}
