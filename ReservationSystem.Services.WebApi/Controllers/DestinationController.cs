using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
    public class DestinationController : Controller
    {
        private readonly IDestinationApplication _destinationApplication;
        private readonly IConfiguration _configuration;

        public DestinationController(IDestinationApplication destinationApplication, IConfiguration configuration)
        {
            _destinationApplication = destinationApplication;
            _configuration = configuration;
        }

        [HttpPost("Post")]
        public async Task<IActionResult> Post([FromBody] DestinationDto destinationDto)
        {
            try
            {
                if (destinationDto == null)
                    return BadRequest();
                var response = await _destinationApplication.Add(destinationDto);
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
        public async Task<IActionResult> Update([FromBody] DestinationDto destinationDto)
        {
            if (destinationDto == null)
                return BadRequest();
            var response = await _destinationApplication.Update(destinationDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _destinationApplication.Delete(id);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var response = await _destinationApplication.Get(Id);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _destinationApplication.GetAll();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAllByCode/{code}")]
        public async Task<IActionResult> GetAllByCode(string code)
        {
            if (string.IsNullOrEmpty(code))
                return BadRequest();          
            var response = await _destinationApplication.GetAllByCode(code);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
    }
}

