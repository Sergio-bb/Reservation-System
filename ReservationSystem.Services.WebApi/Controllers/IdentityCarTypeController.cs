using Microsoft.AspNetCore.Mvc;
using ReservationSystem.Application.DTO;
using ReservationSystem.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystem.Services.WebApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityCardTypeController : Controller
    {
        private readonly IIdentityCardTypeApplication _identityCardTypeApplication;
        public IdentityCardTypeController(IIdentityCardTypeApplication identityCardTypeApplication)
        {
            _identityCardTypeApplication = identityCardTypeApplication;
        }  

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _identityCardTypeApplication.GetAll();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

      
    }

    
}
