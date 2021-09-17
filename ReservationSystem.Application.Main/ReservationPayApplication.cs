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
    public class ReservationPayApplication : IReservationPayApplication
    {
        private readonly IReservationPayDomain _reservationPayDomain;
        private readonly ITouristReservationDomain _touristicReservationDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<ReservationPayApplication> _logger;
        public ReservationPayApplication(IReservationPayDomain reservationPayDomain, ITouristReservationDomain touristicReservationDomain, IMapper mapper, IAppLogger<ReservationPayApplication> logger)
        {
            _reservationPayDomain = reservationPayDomain;
            _touristicReservationDomain = touristicReservationDomain;
            _mapper = mapper;
            _logger = logger;
        }     

        public async Task<Response<ReservationPayDto>> Add(ReservationPayDto reservationPayDto)
        {

            var response = new Response<ReservationPayDto>();
            try
            {
                reservationPayDto.Date = DateTime.Now;
                reservationPayDto.CreatedDate = DateTime.Now;
                var reservationPay = _mapper.Map<ReservationPay>(reservationPayDto);
                var reservationpay = await _reservationPayDomain.Add(reservationPay);
                response.Data = _mapper.Map<ReservationPayDto>(reservationpay);
                await CalculateBalancePendientTopay(reservationPayDto, reservationPay, reservationpay);
                if (response.Data != null)
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

        private async Task CalculateBalancePendientTopay(ReservationPayDto reservationPayDto, ReservationPay reservationPay, ReservationPay reservationpay)
        {
            var reservation = await _touristicReservationDomain.Get(reservationPayDto.ReservationId);
            var payments = await _reservationPayDomain.GetbyReservationId(reservationPay.ReservationId);
            double acumulatePayment = 0;
            foreach (var pay in payments)
            {
                acumulatePayment += pay.Value;
            }
            if (reservation.BalancePendientToPay == 0)
            {
                reservation.BalancePendientToPay = reservation.TotalValue;
                reservation.InitialAbonValue = reservationpay.Value;
                reservation.BalancePendientToPay = reservation.BalancePendientToPay - reservationPay.Value;
                }
            else
            {
                reservation.BalancePendientToPay = reservation.TotalValue - acumulatePayment;
            }


            await _touristicReservationDomain.Update(reservation);
        }


        public async  Task<Response<ReservationPayGetDto>> Get(int id)
        {
            var response = new Response<ReservationPayGetDto>();
            try
            {
                var reservationpay = await _reservationPayDomain.Get(id);
                var reservation = await _touristicReservationDomain.Get(reservationpay.ReservationId);
                response.Data = _mapper.Map<ReservationPayGetDto>(reservationpay);                
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

        public async Task<Response<IEnumerable<ReservationPayGetDto>>> GetAll()
        {
            var response = new Response<IEnumerable<ReservationPayGetDto>>();
            try
            {
                var touristReservationPay = await _reservationPayDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<ReservationPayGetDto>>(touristReservationPay);            
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

        public  async Task<Response<IEnumerable<ReservationPayGetDto>>> GetByReservationId(int reservationId)
        {
            var response = new Response<IEnumerable<ReservationPayGetDto>>();
            try
            {
                var touristReservationPay = await _reservationPayDomain.GetbyReservationId(reservationId);
                var reservation = await _touristicReservationDomain.Get(reservationId);
               
                response.Data = _mapper.Map<IEnumerable<ReservationPayGetDto>>(touristReservationPay);
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
    }
}
