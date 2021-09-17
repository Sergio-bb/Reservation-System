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

    public class DestinationApplication : IDestinationApplication
    {
        private readonly IDestinationDomain _destinationDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<DestinationApplication> _logger;
        public DestinationApplication(IDestinationDomain destinationDomain, IMapper mapper, IAppLogger<DestinationApplication> logger)
        {
            _destinationDomain = destinationDomain;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<bool>> Add(DestinationDto destinationDto)
        {
            var response = new Response<bool>();
            try
            {
                destinationDto.CreatedDate = DateTime.Now;
                var destination = _mapper.Map<Destination>(destinationDto);
                response.Data = await _destinationDomain.Add(destination);
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

        public async Task<Response<bool>> Delete(int destinationId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _destinationDomain.Delete(destinationId);
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

        public async Task<Response<DestinationDto>> Get(int destinationId)
        {
            var response = new Response<DestinationDto>();
            try
            {
                var destination = await _destinationDomain.Get(destinationId);
                response.Data = _mapper.Map<DestinationDto>(destination);
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

        public async Task<Response<IEnumerable<DestinationDto>>> GetAll()
        {
            var response = new Response<IEnumerable<DestinationDto>>();
            try
            {
                var destination = await _destinationDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<DestinationDto>>(destination);
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

        public async Task<Response<IEnumerable<DestinationDto>>> GetAllByCode(string code)
        {
            var response = new Response<IEnumerable<DestinationDto>>();
            try
            {
                var destination = await _destinationDomain.GetByCode(code);
                response.Data = _mapper.Map<IEnumerable<DestinationDto>>(destination);
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
        public async Task<Response<bool>> Update(DestinationDto destinationDto)
        {
            var response = new Response<bool>();
            try
            {
                destinationDto.UpdatedDate = DateTime.Now;
                var destination = _mapper.Map<Destination>(destinationDto);
                response.Data = await _destinationDomain.Update(destination);
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
