using ReservationSystem.Domain.Entity;
using ReservationSystem.Domain.Interface;
using ReservationSystem.Infrastructure.Interface;
using ReservationSystem.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Domain.Core
{
    public class HotelDomain : IHotelDomain
    {
        private readonly IHotelRepository _hotelRepository;
        public HotelDomain(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
        public async Task<bool> Add(Hotel hotel)
        {
            try
            {
                await _hotelRepository.AddAsync(hotel);
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
                var prop = _hotelRepository.GetByIdAsync(id);
                await _hotelRepository.DeleteAsync(prop.Result);
                return true;
            }
            catch (Exception )
            {

                return false;
            }
        }

        public async Task<Hotel> Get(int id)
        {
            return await _hotelRepository.GetByIdAsync(id);
        }

        public  async  Task<bool> Update(Hotel hotel)
        {
            try
            {
                await _hotelRepository.UpdateAsync(hotel);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<List<Hotel>> GetAll()
        {
            return await _hotelRepository.GetAllAsync();
        }
        
        public async Task<List<Hotel>> GetByDestinationId(int destinationId)
        {
            return await _hotelRepository.GetByDestinationId(destinationId);
        }
        public async Task<List<Hotel>> GetAllWintDestination()
        {
            return await _hotelRepository.GetAllWithDestinationAsync();
        }
    }
}
