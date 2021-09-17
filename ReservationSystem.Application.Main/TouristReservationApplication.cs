using AutoMapper;
using ReservationSystem.Application.DTO;
using ReservationSystem.Application.Interface;
using ReservationSystem.Domain.Entity;
using ReservationSystem.Domain.Interface;
using ReservationSystem.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ReservationSystem.Application.Main
{
    public class TouristReservationApplication : ITouristReservationApplication
    {
        private readonly IReservationPayDomain _reservationPayDomain;
        private readonly ITouristReservationDomain _touristReservationDomain;
        private readonly IAgreementDomain _agreementDomain;
        private readonly IHotelDomain _hotelDomain;
        private readonly IAirlineDomain _airlineDomain;
        private readonly IAccommodationDomain _accommodationDomain;
        private readonly ICustomerDomain _customerDomain;
        private readonly IDestinationDomain _destinationDomain; 
        private readonly ITouristReservationPassengerDomain  _touristReservationPassengerDomain;
        private readonly ITouristReservationIncludeDomain _touristReservationIncludeDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<TouristReservationApplication> _logger;
        
        public TouristReservationApplication(ITouristReservationDomain touristReservationDomain,
                                            IReservationPayDomain reservationPayDomain,
                                            IHotelDomain hotelDomain,
                                            IAirlineDomain airlineDomain,
                                            IAccommodationDomain accommodationDomain,
                                            ICustomerDomain customerDomain,
                                            IDestinationDomain destinationDomain,                                           
                                            IMapper mapper, 
                                            IAgreementDomain agreementDomain,
                                            ITouristReservationPassengerDomain touristReservationPassengerDomain,
                                            ITouristReservationIncludeDomain touristReservationIncludeDomain,
                                            IAppLogger<TouristReservationApplication> logger)
        {
            _touristReservationPassengerDomain = touristReservationPassengerDomain;
            _touristReservationIncludeDomain = touristReservationIncludeDomain;
            _touristReservationDomain = touristReservationDomain;
            _hotelDomain = hotelDomain;
            _airlineDomain = airlineDomain;
            _accommodationDomain = accommodationDomain;
            _customerDomain = customerDomain;
            _agreementDomain = agreementDomain;           
            _destinationDomain = destinationDomain;
            _reservationPayDomain = reservationPayDomain;
            _mapper = mapper;
            _logger = logger;
        }     

        public async Task<Response<ReservationDto>> Add(ReservationDto touristRetservationDto)
        {
            var response = new Response<ReservationDto>();
            try
            {
                touristRetservationDto.TotalCancelationDate = touristRetservationDto.TravelDate.AddDays(-10);
                touristRetservationDto.CreatedDate = DateTime.Now;
                touristRetservationDto.ReservationDate = DateTime.Now;
                var touristReservation = _mapper.Map<Reservation>(touristRetservationDto);                
                response.Data = _mapper.Map<ReservationDto>(await _touristReservationDomain.Add(touristReservation));
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
        public async Task<Response<bool>> Delete(int Id)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _touristReservationDomain.Delete(Id);
                if (response.Data)
                {
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

        public async  Task<Response<ReservationGetDto>> Get(int Id)
        {
            var response = new Response<ReservationGetDto>();
            try
            {
                var touristReservation = await _touristReservationDomain.Get(Id);               
                touristReservation.Destination = await _destinationDomain.Get(touristReservation.DestinationId);
                touristReservation.Agreement = await _agreementDomain.Get(touristReservation.AgreementId);
                touristReservation.Hotel = await _hotelDomain.Get(touristReservation.HotelId);
                touristReservation.Airline = await _airlineDomain.Get(touristReservation.AirlineId);
                touristReservation.Accommodation = await _accommodationDomain.Get(touristReservation.AccommodationId);
                touristReservation.Customer = await _customerDomain.Get(touristReservation.CustomerId);
                response.Data = _mapper.Map<ReservationGetDto>(touristReservation);
                response.Data.ReservationPassengers = _mapper.Map<IEnumerable<ReservationPassengerDto>>
                    (await _touristReservationPassengerDomain.GetByReservationId(Id));
                response.Data.ReservationIncludes = _mapper.Map<IEnumerable<ReservationIncludeDto>>
                    (await _touristReservationIncludeDomain.GetByReservationId(Id));
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

        public async Task<Response<IEnumerable<ReservationGetDto>>> GetAll()
        {
            var response = new Response<IEnumerable<ReservationGetDto>>();
            try
            {              
                var hotels = await _hotelDomain.GetAll();
                var airlines = await _airlineDomain.GetAll();
                var acomodatios = await _accommodationDomain.GetAll();
                var customers = await _customerDomain.GetAll();
                var touristReservations = await _touristReservationDomain.GetAll();
                var destinations = await _destinationDomain.GetAll();
                var agreements = await _agreementDomain.GetAll();
                foreach (var item in touristReservations)
                {                 
                    item.Hotel = hotels.FirstOrDefault(x => x.Id == item.HotelId);
                    item.Airline = airlines.FirstOrDefault(x => x.Id == item.AirlineId);
                    item.Accommodation = acomodatios.FirstOrDefault(x => x.Id == item.AccommodationId);
                    item.Customer = customers.FirstOrDefault(x => x.Id == item.CustomerId);
                    item.Destination = destinations.FirstOrDefault(x => x.Id == item.DestinationId);
                    item.Agreement = agreements.FirstOrDefault(x => x.Id == item.AgreementId);
                }
                response.Data = _mapper.Map<IEnumerable<ReservationGetDto>>(touristReservations);
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

        public async Task<Response<IEnumerable<ReservationDto>>> GetAllByCode(string code)
        {
            var response = new Response<IEnumerable<ReservationDto>>();
            try
            {
                var touristReservations = await _touristReservationDomain.GetByCode(code);
                response.Data = _mapper.Map<IEnumerable<ReservationDto>>(touristReservations);
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

        public async Task<Response<IEnumerable<ReservationGetDto>>> GetAllUnderpayment()
        {
            var response = new Response<IEnumerable<ReservationGetDto>>();
            try
            {
                var hotels = await _hotelDomain.GetAll();
                var airlines = await _airlineDomain.GetAll();
                var acomodatios = await _accommodationDomain.GetAll();
                var customers = await _customerDomain.GetAll();
                var reservations = await _touristReservationDomain.GetAllUnderpayment();
                var destinations = await _destinationDomain.GetAll();
                var agreements = await _agreementDomain.GetAll();
                foreach (var item in reservations)
                {
                    item.Hotel = hotels.FirstOrDefault(x => x.Id == item.HotelId);
                    item.Airline = airlines.FirstOrDefault(x => x.Id == item.AirlineId);
                    item.Accommodation = acomodatios.FirstOrDefault(x => x.Id == item.AccommodationId);
                    item.Customer = customers.FirstOrDefault(x => x.Id == item.CustomerId);
                    item.Destination = destinations.FirstOrDefault(x => x.Id == item.DestinationId);
                    item.Agreement = agreements.FirstOrDefault(x => x.Id == item.AgreementId);
                };
                response.Data = _mapper.Map<IEnumerable<ReservationGetDto>>(reservations);
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

        public async Task<Response<bool>> Update(ReservationDto touristReservationDto)
        {
            var response = new Response<bool>();
            try
            {
                touristReservationDto.UpdatedDate = DateTime.Now;
                var touristReservation = _mapper.Map<Reservation>(touristReservationDto);                
                var reservationToEdit = await CalculateToTalValueForEditAgreement(touristReservation);                
                response.Data = await _touristReservationDomain.Update(reservationToEdit);
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

        public async Task<Reservation>CalculateToTalValueForEditAgreement(Reservation reservation)
        {
            var agreement = await _agreementDomain.Get(reservation.AgreementId);
            var pays = await _reservationPayDomain.GetbyReservationId(reservation.Id);
            double totalValuePaid = 0;
            var rateDiscoint = (agreement.Rate / 100);
            foreach (var pay in pays)
            {
                totalValuePaid += pay.Value;
            }
            if (agreement.Rate != 0)
            {
                reservation.TotalValue -= reservation.TotalValue * rateDiscoint;
            }
            reservation.BalancePendientToPay = reservation.TotalValue-totalValuePaid;
            return reservation;
        }
    }
}
