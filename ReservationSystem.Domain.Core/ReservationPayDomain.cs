using ReservationSystem.Domain.Entity;
using ReservationSystem.Domain.Interface;
using ReservationSystem.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReservationSystem.Domain.Core
{
    public class ReservationPayDomain : IReservationPayDomain
    {
        private readonly IReservationPayRepository _reservationPayRepository;
        public ReservationPayDomain(IReservationPayRepository reservationPayRepository)
        {
            _reservationPayRepository = reservationPayRepository;
        }
        public async Task<ReservationPay> Add(ReservationPay reservationPay)
        {
            try
            {
                return await _reservationPayRepository.AddAsync(reservationPay);
           
            }
            catch (Exception e)
            {
                return null;
            }
        }       

        public async Task<ReservationPay> Get(int id)
        {
            return await _reservationPayRepository.GetByIdAsync(id);
        }

        public async Task<List<ReservationPay>> GetAll()
        {
            return await _reservationPayRepository.GetAllAsync();
        }

        public async Task<List<ReservationPay>> GetbyReservationId(int reservationId)
        {
            return await _reservationPayRepository.GetByReservationId(reservationId);
        }
    }
}
