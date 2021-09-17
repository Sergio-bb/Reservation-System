using AutoMapper;
using ReservationSystem.Application.DTO;
using ReservationSystem.Application.Interface;
using ReservationSystem.Domain.Entity;
using ReservationSystem.Domain.Interface;
using ReservationSystem.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Application.Main
{
    public class TouristReservationPassengerApplication : ITouristReservationPassengerApplication
    {
        private readonly ITouristReservationPassengerDomain _touristReservationPassengerDomain;
        private readonly ITouristReservationDomain _touristReservationDomain;
        private readonly IReservationPayDomain _reservationPayDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<TouristReservationPassengerApplication> _logger;
        public TouristReservationPassengerApplication(IReservationPayDomain reservationPayDomain, ITouristReservationPassengerDomain touristReservationPassengerDomain, IMapper mapper, IAppLogger<TouristReservationPassengerApplication> logger, ITouristReservationDomain touristReservationDomain)
        {
            _touristReservationDomain = touristReservationDomain;
            _touristReservationPassengerDomain = touristReservationPassengerDomain;
            _reservationPayDomain = reservationPayDomain;
            _mapper = mapper;
            _logger = logger;
        }     

        public async Task<Response<bool>> Add(ReservationPassengerDto touristReservationPassengerDto)
        {
            var response = new Response<bool>();
            try
            {
                touristReservationPassengerDto.Age = (DateTime.Now.Year - touristReservationPassengerDto.DateBirth.Year);
                touristReservationPassengerDto.CreatedDate = DateTime.Now;
                var touristReservationPassenger = _mapper.Map<ReservationPassenger>(touristReservationPassengerDto);
                response.Data = await _touristReservationPassengerDomain.Add(touristReservationPassenger);
                var reservation = await _touristReservationDomain.Get(touristReservationPassenger.TouristReservationId);
                CalculateNewTotalValue(touristReservationPassenger, reservation);
                if (response.Data)
                {                                       
                    response.IsSuccess = true;
                    response.Message = "Successful registration!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        private async void CalculateNewTotalValue(ReservationPassenger touristReservationPassenger, Reservation reservation)
        {
            reservation.NumberPassengers++;
            if (touristReservationPassenger.Age > 15)
            {
                reservation.TotalValue +=  reservation.AdultRate;
            }
            else if (touristReservationPassenger.Age > 3 && touristReservationPassenger.Age < 15)
            {
                reservation.TotalValue +=  reservation.ChildRate;
            }
            else
            {
                reservation.TotalValue +=  reservation.InfantRate;                
            }
            await CalculatebalancePendientToPay(reservation);
        }
        private async void CalculateNewTotalValuePassengerDelete(ReservationPassenger touristReservationPassenger, Reservation reservation)
        {
            reservation.NumberPassengers--;
            if (touristReservationPassenger.Age > 15)
            {
                reservation.TotalValue = reservation.TotalValue - reservation.AdultRate;
            }
            if (touristReservationPassenger.Age > 3 && touristReservationPassenger.Age < 15)
            {
                reservation.TotalValue = reservation.TotalValue - reservation.ChildRate;
            }
            else
            {
                reservation.TotalValue = reservation.TotalValue - reservation.InfantRate;
            }
            await CalculatebalancePendientToPay(reservation);
        }

        private async Task CalculatebalancePendientToPay(Reservation reservation)
        {
            var payments = await _reservationPayDomain.GetbyReservationId(reservation.Id);
            if (payments.Count != 0)
            {
                double acumulatePayments = 0;
                foreach (var pay in payments)
                {
                    acumulatePayments += pay.Value;
                }
                reservation.BalancePendientToPay = reservation.TotalValue - acumulatePayments;
            }   
            
            var recuest =await _touristReservationDomain.Update(reservation);

        }

        public async Task<Response<bool>> Delete(int Id)
        {
            var response = new Response<bool>();
            try
            {
                var passenger = await _touristReservationPassengerDomain.Get(Id);
                var reservation = await _touristReservationDomain.Get(passenger.TouristReservationId);
                response.Data = await _touristReservationPassengerDomain.Delete(Id);
               
                if (response.Data)
                {
                    CalculateNewTotalValuePassengerDelete(passenger, reservation);
                    await _touristReservationDomain.Update(reservation);

                    response.IsSuccess = true;
                    response.Message = "Successful removal!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        
        public async  Task<Response<ReservationPassengerDto>> Get(int Id)
        {
            var response = new Response<ReservationPassengerDto>();
            try
            {
                var touristReservationPassenger = await _touristReservationPassengerDomain.Get(Id);
                response.Data = _mapper.Map<ReservationPassengerDto>(touristReservationPassenger);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful consultation!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

       

        public async Task<Response<IEnumerable<ReservationPassengerDto>>> GetAll()
        {
            var response = new Response<IEnumerable<ReservationPassengerDto>>();
            try
            {
                var touristReservationPassenger = await _touristReservationPassengerDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<ReservationPassengerDto>>(touristReservationPassenger);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful consultation!!!";
                    _logger.LogInformation("Successful consultation!!!");
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.LogError(e.Message);
            }
            return response;
        }

        public async Task<Response<IEnumerable<ReservationPassengerDto>>> GetByReservationId(int reservationId)
        {
            var response = new Response<IEnumerable<ReservationPassengerDto>>();
            try
            {
                var passengers = await _touristReservationPassengerDomain.GetByReservationId(reservationId);
                response.Data = _mapper.Map<IEnumerable<ReservationPassengerDto>>(passengers);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful consultation!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<bool>> Update(ReservationPassengerDto touristReservationPassengerDto)
        {
            var response = new Response<bool>();
            try
            {
                touristReservationPassengerDto.UpdatedDate = DateTime.Now;
                var touristReservationPassenger = _mapper.Map<ReservationPassenger>(touristReservationPassengerDto);
                response.Data = await _touristReservationPassengerDomain.Update(touristReservationPassenger);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful update!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
    }
}
