
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
    public class CustomerController : Controller
    {
        private readonly ICustomerApplication _customerApplication;
        private readonly IConfiguration _configuration;
       
        public CustomerController (ICustomerApplication customerApplication, IConfiguration configuration)
        {
            _configuration = configuration;
            _customerApplication = customerApplication;
        }
        [HttpPost("Post")]
        public async Task<IActionResult> Post([FromBody] CustomerDto customerDto)
        {
            try
            {
                if (customerDto == null)
                    return BadRequest();
                var response = await _customerApplication.Add(customerDto);
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
        public async Task<IActionResult> Update([FromBody] CustomerDto customerDto)
        {
            if (customerDto == null)
                return BadRequest();
            var response = await _customerApplication.Update(customerDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var response = await _customerApplication.Delete(Id);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("Get/{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var response = await _customerApplication.Get(Id);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _customerApplication.GetAll();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        
    }
}
