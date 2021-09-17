using ReservationSystem.Domain.Entity;
using ReservationSystem.Domain.Interface;
using ReservationSystem.Infrastructure.Interface;
using ReservationSystem.Infrastructure.Interface.Base;
using ReservationSystem.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Domain.Core
{
    public class AcommodationDomain : IAccommodationDomain

    {
        private readonly IAccommodationRepository _accommodationRoomRepository;
        public AcommodationDomain(IAccommodationRepository accommodationRoomRepository)
        {
            _accommodationRoomRepository = accommodationRoomRepository;
        }

        public async Task<bool> Add(Accommodation accommodationRoom)
        {
            try
            {
                await _accommodationRoomRepository.AddAsync(accommodationRoom);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int accommodationRoomId)
        {
            try
            {
                var prop = _accommodationRoomRepository.GetByIdAsync(accommodationRoomId);
                await _accommodationRoomRepository.DeleteAsync(prop.Result);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<Accommodation> Get(int accommodationRoomId)
        {
            return await _accommodationRoomRepository.GetByIdAsync(accommodationRoomId);
        }

        public async Task<List<Accommodation>> GetAll()
        {
            return await _accommodationRoomRepository.GetAllAsync();
        }

        public async Task<bool> Update(Accommodation accommodationRoom)
        {
            try
            {
                await _accommodationRoomRepository.UpdateAsync(accommodationRoom);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
