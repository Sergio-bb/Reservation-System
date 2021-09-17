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
    public class TouristReservationIcludeDomain : ITouristReservationIncludeDomain
    {
        private readonly ITouristReservationIncludeRepository _touristReservationIncludeRepository;
        public TouristReservationIcludeDomain(ITouristReservationIncludeRepository touristReservationIncludeRepository)
        {
            _touristReservationIncludeRepository = touristReservationIncludeRepository;
        }
        public async Task<int> Add(ReservationInclude touristReservationInclude)
        {
            try
            {
                await _touristReservationIncludeRepository.AddAsync(touristReservationInclude);
                return touristReservationInclude.Id;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        public async Task<bool> Delete(int touristReservationIncludeId, int idReservation)
        {            
            try
            {
                var prop = _touristReservationIncludeRepository.GetByIdIncludeAndReservationIdAsync(touristReservationIncludeId, idReservation);
                await _touristReservationIncludeRepository.DeleteAsync(prop.Result);
                return true;
            }
            catch (Exception e  )
            {

                return false;
            }
        }     

        public async Task<ReservationInclude> Get(int touristReservationIncludeId)
        {
            return await _touristReservationIncludeRepository.GetByIdAsync(touristReservationIncludeId);
        }

        public async Task<List<ReservationInclude>> GetAll()
        {
            return await _touristReservationIncludeRepository.GetAllAsync();
        }

        public async Task<List<ReservationInclude>> GetByReservationId(int reservationId)
        {
            return await _touristReservationIncludeRepository.GetByReservationId(reservationId);
        }       

        public  async  Task<bool> Update(ReservationInclude touristReservationInclude)
        {
            try
            {
                await _touristReservationIncludeRepository.UpdateAsync(touristReservationInclude);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
