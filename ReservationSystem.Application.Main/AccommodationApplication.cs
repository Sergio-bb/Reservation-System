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
    public class AccommodationApplication : IAccommodationRoomApplication
    {
        private readonly IAccommodationDomain _accommodationRoomDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<AccommodationApplication> _logger;
        public AccommodationApplication(IAccommodationDomain accommodationRoomDomain, IMapper mapper, IAppLogger<AccommodationApplication> logger)
        {
            _accommodationRoomDomain = accommodationRoomDomain;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Response<bool>> Add(AccommodationDto accommodationRoomDto)
        {
            var response = new Response<bool>();
            try
            {
                accommodationRoomDto.CreatedDate = DateTime.Now;
                var accommodationRoom = _mapper.Map<Accommodation>(accommodationRoomDto);
                response.Data = await _accommodationRoomDomain.Add(accommodationRoom);
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

        public async Task<Response<bool>> Delete(int accommodationRoomId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _accommodationRoomDomain.Delete(accommodationRoomId);
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

        public async Task<Response<AccommodationDto>> Get(int accommodationRoomId)
        {
            var response = new Response<AccommodationDto>();
            try
            {
                var accommodationRoom = await _accommodationRoomDomain.Get(accommodationRoomId);
                response.Data = _mapper.Map<AccommodationDto>(accommodationRoom);
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

        public async Task<Response<IEnumerable<AccommodationDto>>> GetAll()
        {
            var response = new Response<IEnumerable<AccommodationDto>>();
            try
            {
                var accommodationRoom = await _accommodationRoomDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<AccommodationDto>>(accommodationRoom);
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

        public async Task<Response<bool>> Update(AccommodationDto accommodationRoomDto)
        {
            var response = new Response<bool>();
            try
            {
                accommodationRoomDto.UpdatedDate = DateTime.Now;
                var accommodationRoom = _mapper.Map<Accommodation>(accommodationRoomDto);
                response.Data = await _accommodationRoomDomain.Update(accommodationRoom);
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
