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
    public class TouristReservationDomain : ITouristReservationDomain
    {
        private readonly ITouristReservationRepositoy _touristReservationRepositoy;
        public TouristReservationDomain(ITouristReservationRepositoy touristReservationRepositoy)
        {
            _touristReservationRepositoy = touristReservationRepositoy;
        }
        public async Task<Reservation> Add(Reservation touristReservation)
        {
            try
            {
                return await _touristReservationRepositoy.AddAsync(touristReservation);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> Delete(int touristReservationId)
        {            
            try
            {
                var prop = _touristReservationRepositoy.GetByIdAsync(touristReservationId);
                await _touristReservationRepositoy.DeleteAsync(prop.Result);
                return true;
            }
            catch (Exception )
            {

                return false;
            }
        }

        public async Task<Reservation> Get(int touristReservationId)
        {
            return await _touristReservationRepositoy.GetByIdAsync(touristReservationId);
        }

        public async Task<List<Reservation>> GetAll()
        {
            return await _touristReservationRepositoy.GetAllAsync();
        }
        public async Task<List<Reservation>> GetAllUnderpayment()
        {
            return await _touristReservationRepositoy.GetAllUnderpayment();
        }

        public async Task<IEnumerable<Reservation>> GetByCode(string code)
        {
            return await _touristReservationRepositoy.GetByCode(code);
        }

        public  async  Task<bool> Update(Reservation touristReservation)
        {
            try
            {
                await _touristReservationRepositoy.UpdateAsync(touristReservation);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
