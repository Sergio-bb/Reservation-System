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
    public class AppParametersApplication : IAppParametersApplication
    {
        private readonly IAppParametersDomain _appParametersDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<AppParametersApplication> _logger;
        public AppParametersApplication(IAppParametersDomain appParametersDomain, IMapper mapper, IAppLogger<AppParametersApplication> logger)
        {
            _appParametersDomain = appParametersDomain;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<bool>> Add(AppParametersDto appParametersDto)
        {
            var response = new Response<bool>();
            try
            {
                appParametersDto.CreatedDate = DateTime.Now;
                var appParameters = _mapper.Map<AppParameters>(appParametersDto);
                response.Data = await _appParametersDomain.Add(appParameters);
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

        public async Task<Response<bool>> Delete(int Id)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _appParametersDomain.Delete(Id);
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

        public async Task<Response<AppParametersDto>> Get(int Id)
        {
            var response = new Response<AppParametersDto>();
            try
            {
                var appParameters = await _appParametersDomain.Get(Id);
                response.Data = _mapper.Map<AppParametersDto>(appParameters);
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

        public async Task<Response<IEnumerable<AppParametersDto>>> GetAll()
        {
            var response = new Response<IEnumerable<AppParametersDto>>();
            try
            {
                var appParameters = await _appParametersDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<AppParametersDto>>(appParameters);
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

        public async Task<Response<IEnumerable<AppParametersDto>>> GetAllByCode(string code)
        {
            var response = new Response<IEnumerable<AppParametersDto>>();
            try
            {
                var appParameters = await _appParametersDomain.GetByCode(code);
                response.Data = _mapper.Map<IEnumerable<AppParametersDto>>(appParameters);
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

        public async Task<Response<bool>> Update(AppParametersDto appParametersDto)
        {
            var response = new Response<bool>();
            try
            {
                appParametersDto.UpdatedDate = DateTime.Now;
                var aapParameters = _mapper.Map<AppParameters>(appParametersDto);
                response.Data = await _appParametersDomain.Update(aapParameters);
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
