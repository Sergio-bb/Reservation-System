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
    public class TouristReservationPassengerDomain : ITouristReservationPassengerDomain
    {
        private readonly ITouristReservationPassengerRepository _touristReservationPassengerRepository;
        public TouristReservationPassengerDomain(ITouristReservationPassengerRepository touristReservationPassengerRepository)
        {
            _touristReservationPassengerRepository = touristReservationPassengerRepository;
        }
        public async Task<bool> Add(ReservationPassenger touristReservationPassenger)
        {
            try
            {
                await _touristReservationPassengerRepository.AddAsync(touristReservationPassenger);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int Id)
        {            
            try
            {
                var prop = _touristReservationPassengerRepository.GetByIdAsync(Id);
                await _touristReservationPassengerRepository.DeleteAsync(prop.Result);
                return true;
            }
            catch (Exception )
            {

                return false;
            }
        }

        public async Task<ReservationPassenger> Get(int Id)
        {
            return await _touristReservationPassengerRepository.GetByIdAsync(Id);
        }

        public async Task<List<ReservationPassenger>> GetAll()
        {
            return await _touristReservationPassengerRepository.GetAllAsync();
        }

        public async Task<List<ReservationPassenger>> GetByReservationId(int reservationId)
        {
            return await _touristReservationPassengerRepository.GetByDestinationId(reservationId);
        }

        public  async  Task<bool> Update(ReservationPassenger touristReservationPassenger)
        {
            try
            {
                await _touristReservationPassengerRepository.UpdateAsync(touristReservationPassenger);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
