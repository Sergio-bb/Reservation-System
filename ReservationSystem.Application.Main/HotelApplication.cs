using AutoMapper;
using ReservationSystem.Application.DTO;
using ReservationSystem.Application.Interface;
using ReservationSystem.Domain.Entity;
using ReservationSystem.Domain.Interface;
using ReservationSystem.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReservationSystem.Application.Main
{
    public class HotelApplication : IHotelApplication
    {
        private readonly IHotelDomain _hotelDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<HotelApplication> _logger;
        public HotelApplication(IHotelDomain hotelDomain, IMapper mapper, IAppLogger<HotelApplication> logger)
        {
            _hotelDomain = hotelDomain;
            _mapper = mapper;
            _logger = logger;
        }     

        public async Task<Response<bool>> Add(HotelDto hotelDto)
        {

            var response = new Response<bool>();
            try
            {
                hotelDto.CreatedDate = DateTime.Now;
                var hotel = _mapper.Map<Hotel>(hotelDto);
                response.Data = await _hotelDomain.Add(hotel);
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

        public async Task<Response<bool>> Delete(int id)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _hotelDomain.Delete(id);
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

        public async  Task<Response<HotelGetDto>> Get(int id)
        {
            var response = new Response<HotelGetDto>();
            try
            {
                var hotel = await _hotelDomain.Get(id);
                response.Data = _mapper.Map<HotelGetDto>(hotel);
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
        public async Task<Response<IEnumerable<HotelGetDto>>> GetByDestinationId(int destinationId)
        {
            var response = new Response<IEnumerable<HotelGetDto>>();
            try
            {
                var hotels = await _hotelDomain.GetByDestinationId(destinationId);
                response.Data = _mapper.Map<IEnumerable<HotelGetDto>>(hotels);
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
        public async Task<Response<IEnumerable<HotelGetDto>>> GetAll()
        {
            var response = new Response<IEnumerable<HotelGetDto>>();
            try
            {
                var hotel = await _hotelDomain.GetAllWintDestination();
                response.Data = _mapper.Map<IEnumerable<HotelGetDto>>(hotel);
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

     

        public async Task<Response<bool>> Update(HotelDto hotelDto)
        {
            var response = new Response<bool>();
            try
            {
                hotelDto.UpdatedDate = DateTime.Now;
                var hotel = _mapper.Map<Hotel>(hotelDto);
                response.Data = await _hotelDomain.Update(hotel);
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
