
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ReservationSystem.Application.DTO;
using ReservationSystem.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystem.Services.WebApi.Controllers
{    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : Controller
    {
        private readonly IProviderApplication _providerApplication;
        private readonly IConfiguration _configuration;
        public ProviderController(IProviderApplication providerApplication, IConfiguration configuration)
        {
            _providerApplication = providerApplication;
            _configuration = configuration;
        }

        [HttpPost("Post")]
        public async Task<IActionResult> Post([FromBody] ProviderDto supplierDto)
        {
            try
            {
                if (supplierDto == null)
                    return BadRequest();
                var response = await _providerApplication.Add(supplierDto);
                if (response.IsSuccess)
                    return Ok(response);
                return BadRequest(response.Message);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] ProviderDto supplierDto)
        {
            if (supplierDto == null)
                return BadRequest();
            var response = await _providerApplication.Update(supplierDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _providerApplication.Delete(id);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("Get/{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var response = await _providerApplication.Get(Id);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _providerApplication.GetAll();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
    }
}
