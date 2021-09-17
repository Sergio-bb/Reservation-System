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
    public class AirlineApplication : IAirlineApplication
    {
        private readonly IAirlineDomain _airelineDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<AirlineApplication> _logger;
        public AirlineApplication(IAirlineDomain airlineDomain, IMapper mapper, IAppLogger<AirlineApplication> logger)
        {
            _airelineDomain = airlineDomain;
            _mapper = mapper;
            _logger = logger;
        }     

        public async Task<Response<bool>> Add(AirlineDto airlineDto)
        {

            var response = new Response<bool>();
            try
            {
                airlineDto.CreatedDate = DateTime.Now;
                var airline = _mapper.Map<Airline>(airlineDto);
                response.Data = await _airelineDomain.Add(airline);
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
                response.Data = await _airelineDomain.Delete(id);
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

        public async  Task<Response<AirlineDto>> Get(int id)
        {
            var response = new Response<AirlineDto>();
            try
            {
                var airline = await _airelineDomain.Get(id);
                response.Data = _mapper.Map<AirlineDto>(airline);
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

        public async Task<Response<IEnumerable<AirlineDto>>> GetAll()
        {
            var response = new Response<IEnumerable<AirlineDto>>();
            try
            {
                var airline = await _airelineDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<AirlineDto>>(airline);
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

     

        public async Task<Response<bool>> Update(AirlineDto airlineDto)
        {
            var response = new Response<bool>();
            try
            {
                airlineDto.UpdatedDate = DateTime.Now;
                var airline = _mapper.Map<Airline>(airlineDto);
                response.Data = await _airelineDomain.Update(airline);
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
