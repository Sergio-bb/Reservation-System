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
    public class IncludeApplication : IIncludeApplication
    {
        private readonly IIncludeDomain _includeDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<IncludeApplication> _logger;
        public IncludeApplication(IIncludeDomain includeDomain, IMapper mapper, IAppLogger<IncludeApplication> logger)
        {
            _includeDomain = includeDomain;
            _mapper = mapper;
            _logger = logger;
        }     

        public async Task<Response<bool>> Add(IncludeDto includeDto)
        {
            var response = new Response<bool>();
            try
            {
                includeDto.CreatedDate = DateTime.Now;
                var include = _mapper.Map<Include>(includeDto);
                response.Data = await _includeDomain.Add(include);
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
                response.Data = await _includeDomain.Delete(Id);
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

        public async  Task<Response<IncludeDto>> Get(int Id)
        {
            var response = new Response<IncludeDto>();
            try
            {
                var include = await _includeDomain.Get(Id);
                response.Data = _mapper.Map<IncludeDto>(include);
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

        public async Task<Response<IEnumerable<IncludeDto>>> GetAll()
        {
            var response = new Response<IEnumerable<IncludeDto>>();
            try
            {
                var include = await _includeDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<IncludeDto>>(include);
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

        public async Task<Response<IEnumerable<IncludeDto>>> GetAllByCode(string code)
        {
            var response = new Response<IEnumerable<IncludeDto>>();
            try
            {
                var include = await _includeDomain.GetByCode(code);
                response.Data = _mapper.Map<IEnumerable<IncludeDto>>(include);
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

        public async Task<Response<bool>> Update(IncludeDto includeDto)
        {
            var response = new Response<bool>();
            try
            {
                includeDto.UpdatedDate = DateTime.Now;
                var include = _mapper.Map<Include>(includeDto);
                response.Data = await _includeDomain.Update(include);
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
