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
    public class AirlineDomain : IAirlineDomain
    {
        private readonly IAirlineRepository _airlineRepository;
        public AirlineDomain(IAirlineRepository airlineRepository)
        {
            _airlineRepository = airlineRepository;
        }
        public async Task<bool> Add(Airline airline)
        {
            try
            {
                await _airlineRepository.AddAsync(airline);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {            
            try
            {
                var prop = _airlineRepository.GetByIdAsync(id);
                await _airlineRepository.DeleteAsync(prop.Result);
                return true;
            }
            catch (Exception )
            {

                return false;
            }
        }

        public async Task<Airline> Get(int id)
        {
            return await _airlineRepository.GetByIdAsync(id);
        }

        public async Task<List<Airline>> GetAll()
        {
            return await _airlineRepository.GetAllAsync();
        }

        

        public  async  Task<bool> Update(Airline airline)
        {
            try
            {
                await _airlineRepository.UpdateAsync(airline);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
