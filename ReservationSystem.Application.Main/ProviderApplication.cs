using AutoMapper;
using Microsoft.Extensions.Logging;
using ReservationSystem.Application.DTO;
using ReservationSystem.Application.Interface;
using ReservationSystem.Domain.Core;
using ReservationSystem.Domain.Entity;
using ReservationSystem.Domain.Interface;
using ReservationSystem.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Application.Main
{
    public class ProviderApplication : IProviderApplication

    {
        private readonly IProviderDomain _providerDomain;
        private readonly IIdentityCardTypeDomain _identityCardTypeDomain;
        private readonly IMapper _mapper;
        private readonly ILogger<ProviderApplication> _logger;
        public ProviderApplication(IProviderDomain providerDomain, IIdentityCardTypeDomain identityCardTypeDomain, IMapper mapper, ILogger<ProviderApplication> logger)
        {
            _providerDomain = providerDomain;
            _identityCardTypeDomain = identityCardTypeDomain;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Response<bool>> Add(ProviderDto supplierDto)
        {
            var response = new Response<bool>();
            try
            {
                supplierDto.CreatedDate = DateTime.Now;
                var supplier = _mapper.Map<Provider>(supplierDto);
                response.Data = await _providerDomain.Add(supplier);
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

        public async Task<Response<bool>> Delete(int supplierId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _providerDomain.Delete(supplierId);
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
        public async Task<Response<ProviderGetDto>> Get(int id)
        {
            var response = new Response<ProviderGetDto>();
            try
            {
                var provider = await _providerDomain.Get(id);
                provider.IdentityCardType = await _identityCardTypeDomain.Get(provider.IdentityCardTypeId);
                response.Data = _mapper.Map<ProviderGetDto>(provider);
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

        public async Task<Response<IEnumerable<ProviderGetDto>>> GetAll()
        {
            var response = new Response<IEnumerable<ProviderGetDto>>();
            try
            {
                var customer = await _providerDomain.GetAllWithDocumentType();
                response.Data = _mapper.Map<IEnumerable<ProviderGetDto>>(customer);
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

        public async Task<Response<bool>> Update(ProviderDto supplierDto)
        {
            var response = new Response<bool>();
            try
            {
                supplierDto.UpdatedDate = DateTime.Now;
                var supplier = _mapper.Map<Provider>(supplierDto);
                response.Data = await _providerDomain.Update(supplier);
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
