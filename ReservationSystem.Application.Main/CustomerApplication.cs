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
    public class CustomerApplication : ICustomerApplication
    {
        private readonly ICustomerDomain _customerDomain;
        private readonly IIdentityCardTypeDomain _identityCardTypeDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<CustomerApplication> _logger;
        public CustomerApplication(ICustomerDomain customerDomain, IIdentityCardTypeDomain identityCardTypeDomain, IMapper mapper, IAppLogger<CustomerApplication> logger)
        {
            _customerDomain = customerDomain;
            _identityCardTypeDomain = identityCardTypeDomain;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Response<bool>> Add(CustomerDto customerDto)
        {
            var response = new Response<bool>();
            try
            {
                customerDto.CreatedDate = DateTime.Now;
                var customer = _mapper.Map<Customer>(customerDto);
                response.Data = await _customerDomain.Add(customer);
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

        public async Task<Response<bool>> Delete(int customerId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _customerDomain.Delete(customerId);
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

        public async Task<Response<CustomerGetDto>> Get(int customerId)
        {
            var response = new Response<CustomerGetDto>();
            try
            {
                var customer = await _customerDomain.Get(customerId);
                customer.IdentityCardType = await _identityCardTypeDomain.Get(customer.IdentityCardTypeId);
                response.Data = _mapper.Map<CustomerGetDto>(customer);
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

        public async Task<Response<IEnumerable<CustomerGetDto>>> GetAll()
        {
            var response = new Response<IEnumerable<CustomerGetDto>>();
            try
            {
                var customer = await _customerDomain.GetAllWithDocumentType();
                response.Data = _mapper.Map<IEnumerable<CustomerGetDto>>(customer);
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

        public async Task<Response<bool>> Update(CustomerDto customerDto)
        {
            var response = new Response<bool>();
            try
            {
                customerDto.UpdatedDate = DateTime.Now;
                var customer = _mapper.Map<Customer>(customerDto);
                response.Data = await _customerDomain.Update(customer);
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
