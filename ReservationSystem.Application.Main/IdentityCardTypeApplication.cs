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
    public class IdentityCardTypeApplication : IIdentityCardTypeApplication
    {
        private readonly IIdentityCardTypeDomain _identityCardTypeDomain;
        private readonly IMapper _mapper;
        private readonly IAppLogger<IdentityCardTypeApplication> _logger;
        public IdentityCardTypeApplication(IIdentityCardTypeDomain identityCardTypeDomain, IMapper mapper, IAppLogger<IdentityCardTypeApplication> logger)
        {
            _identityCardTypeDomain = identityCardTypeDomain;
            _mapper = mapper;
            _logger = logger;
        }

       



        public async Task<Response<IEnumerable<IdentityCardTypeDto>>> GetAll()
        {
            var response = new Response<IEnumerable<IdentityCardTypeDto>>();
            try
            {
                var identityCardTypes = await _identityCardTypeDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<IdentityCardTypeDto>>(identityCardTypes);
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
