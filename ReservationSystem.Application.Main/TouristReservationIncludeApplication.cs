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
    public class TouristReservationIncludeApplication : ITouristReservationIncludeApplication
    {
        private readonly IIncludeDomain _includeDomain;
        private readonly ITouristReservationIncludeDomain _touristReservationIncludeDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<TouristReservationIncludeApplication> _logger;
        public TouristReservationIncludeApplication(ITouristReservationIncludeDomain touristReservationIncludeDomain, IMapper mapper, IAppLogger<TouristReservationIncludeApplication> logger, IIncludeDomain includeDomain)
        {
            _includeDomain = includeDomain;
            _touristReservationIncludeDomain = touristReservationIncludeDomain;
            _mapper = mapper;
            _logger = logger;
        }     

        public async Task<Response<int>> Add(ReservationIncludeDto touristReservationIncludeDto)        
        {
            var response = new Response<int>();
            try
            {
                touristReservationIncludeDto.CreatedDate = DateTime.Now;
                var include = await _includeDomain.Get(touristReservationIncludeDto.IncludeId);
                var touristReservationInclude = _mapper.Map<ReservationInclude>(touristReservationIncludeDto);
                touristReservationInclude.Code = include.Code;
                response.Data = await _touristReservationIncludeDomain.Add(touristReservationInclude);
                if (response.Data!=0)
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

        public async Task<Response<bool>> Delete(int Id, int idReservation)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _touristReservationIncludeDomain.Delete(Id, idReservation);
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

        public async  Task<Response<ReservationIncludeDto>> Get(int Id)
        {
            var response = new Response<ReservationIncludeDto>();
            try
            {
                var touristReservationInclude = await _touristReservationIncludeDomain.Get(Id);                                
                response.Data = _mapper.Map<ReservationIncludeDto>(touristReservationInclude);
                
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

        public async Task<Response<IEnumerable<ReservationIncludeDto>>> GetAll()
        {
            var response = new Response<IEnumerable<ReservationIncludeDto>>();
            try
            {
                var touristReservationInclude = await _touristReservationIncludeDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<ReservationIncludeDto>>(touristReservationInclude);
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

        public async Task<Response<IEnumerable<ReservationIncludeDto>>> GetByReservationId(int reservationId)
        {
            var response = new Response<IEnumerable<ReservationIncludeDto>>();
            try
            {
                var reservationIncludes = await _touristReservationIncludeDomain.GetByReservationId(reservationId);
                response.Data = _mapper.Map<IEnumerable<ReservationIncludeDto>>(reservationIncludes);
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

        public async Task<Response<bool>> Update(ReservationIncludeDto touristReservationIncludeDto)
        {
            var response = new Response<bool>();
            try
            {
                var touristReservationInclude = _mapper.Map<ReservationInclude>(touristReservationIncludeDto);
                response.Data = await _touristReservationIncludeDomain.Update(touristReservationInclude);
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
