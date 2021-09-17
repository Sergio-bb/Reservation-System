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
    public class TouristReservationController : Controller
    {
        private readonly ITouristReservationApplication _touristReservationApplication;
        public TouristReservationController(ITouristReservationApplication touristReservationApplication)
        {
            _touristReservationApplication = touristReservationApplication;
        }
        
        [HttpPost("post")]
        public async Task<IActionResult>Post([FromBody] ReservationDto touristReservationDto)
        {
            try
            {
                if (touristReservationDto == null)
                    return BadRequest();
                
                var response = await _touristReservationApplication.Add(touristReservationDto);
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
        public async Task<IActionResult> Update([FromBody] ReservationDto touristReservationDto)
        {
            if (touristReservationDto == null)
                return BadRequest();
            var response = await _touristReservationApplication.Update(touristReservationDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _touristReservationApplication.Delete(id);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("Get/{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var response = await _touristReservationApplication.Get(Id);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _touristReservationApplication.GetAll();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAllByCode/{code}")]
        public async Task<IActionResult> GetAllByCode(string code)
        {
            if (string.IsNullOrEmpty(code))
                return BadRequest();
            var response = await _touristReservationApplication.GetAllByCode(code);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAllUnderpayment")]
        public async Task<IActionResult> GetAllUnderpayment()
        {
            var response = await _touristReservationApplication.GetAllUnderpayment();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

    }


}
