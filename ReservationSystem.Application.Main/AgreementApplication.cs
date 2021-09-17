using AutoMapper;
using ReservationSystem.Application.DTO;
using ReservationSystem.Application.Interface;
using ReservationSystem.Domain.Entity;
using ReservationSystem.Domain.Interface;
using ReservationSystem.Transversal.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ReservationSystem.Application.Main
{
    public class AgreementApplication : IAgreementApplication
    {
        private readonly IAgreementDomain _agreementDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<AgreementApplication> _logger;
        public AgreementApplication(IAgreementDomain agreementDomain, IMapper mapper, IAppLogger<AgreementApplication> logger)
        {
            _agreementDomain = agreementDomain;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<bool>> Add(AgreementDto agreementDto)
        {
            var response = new Response<bool>();
            try
            {
                agreementDto.CreatedDate = DateTime.Now;
                var agreement = _mapper.Map<Agreement>(agreementDto);
                response.Data = await _agreementDomain.Add(agreement);
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

        public async Task<Response<bool>> Update(AgreementDto agreementDto)
        {
            var response = new Response<bool>();
            try
            {
                agreementDto.UpdatedDate = DateTime.Now;
                var agreement = _mapper.Map<Agreement>(agreementDto);
                response.Data = await _agreementDomain.Update(agreement);
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

        public async Task<Response<bool>> Delete(int agreementId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _agreementDomain.Delete(agreementId);
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

        public async Task<Response<AgreementDto>> Get(int agreementId)
        {
            var response = new Response<AgreementDto>();
            try
            {
                var agreement = await _agreementDomain.Get(agreementId);
                response.Data = _mapper.Map<AgreementDto>(agreement);
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

        public async Task<Response<IEnumerable<AgreementDto>>> GetAll()
        {
            var response = new Response<IEnumerable<AgreementDto>>();
            try
            {
                var agreement = await _agreementDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<AgreementDto>>(agreement);
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

        public async Task<Response<IEnumerable<AgreementDto>>> GetAllByCode(string code)
        {
            var response = new Response<IEnumerable<AgreementDto>>();
            try
            {
                var agreement = await _agreementDomain.GetByCode(code);
                response.Data = _mapper.Map<IEnumerable<AgreementDto>>(agreement);
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
