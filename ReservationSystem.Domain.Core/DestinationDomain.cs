using ReservationSystem.Domain.Entity;
using ReservationSystem.Domain.Interface;
using ReservationSystem.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Domain.Core
{
    public class DestinationDomain : IDestinationDomain
    {
        private readonly IDestinationRepository _destinationRepository;
        public DestinationDomain(IDestinationRepository destinationRepository)
        {
            _destinationRepository = destinationRepository;
        }

        public async Task<bool> Add(Destination destination)
        {
            try
            {
                await _destinationRepository.AddAsync(destination);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> Update(Destination destination)
        {
            try
            {
                await _destinationRepository.UpdateAsync(destination);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int destinationId)
        {
            try
            {
                var prop = _destinationRepository.GetByIdAsync(destinationId);
                await _destinationRepository.DeleteAsync(prop.Result);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Destination> Get(int destinationId)
        {
            return await _destinationRepository.GetByIdAsync(destinationId);
        }

        public async Task<List<Destination>> GetAll()
        {
            return await _destinationRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Destination>> GetByCode(string code)
        {
            return await _destinationRepository.GetByCode(code);
        }

        
    }
}
