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
    public class AccommodationController : Controller
    {
        private readonly IAccommodationRoomApplication _aacommodationRoomApplication;
        private readonly IConfiguration _configuration;
        
        public AccommodationController (IAccommodationRoomApplication accommodationRoomApplication, IConfiguration configuration)
        {
            _aacommodationRoomApplication = accommodationRoomApplication;
            _configuration = configuration;
        }

        [HttpPost("Post")]
        public async Task<IActionResult> Post([FromBody] AccommodationDto accommodationRoomDto)
        {
            try
            {
                if (accommodationRoomDto == null)
                    return BadRequest();
                var response = await _aacommodationRoomApplication.Add(accommodationRoomDto);
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
        public async Task<IActionResult> Update([FromBody] AccommodationDto accommodationRoomDto)
        {
            if (accommodationRoomDto == null)
                return BadRequest();
            var response = await _aacommodationRoomApplication.Update(accommodationRoomDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _aacommodationRoomApplication.Delete(id);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
        [HttpGet("Get/{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var response = await _aacommodationRoomApplication.Get(Id);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _aacommodationRoomApplication.GetAll();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
    }
}
