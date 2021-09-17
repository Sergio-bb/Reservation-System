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
    public class TouristReservationIncludeController : Controller
    {
        private readonly ITouristReservationIncludeApplication _touristReservationIncludeApplication;
        public TouristReservationIncludeController(ITouristReservationIncludeApplication touristReservationIncludeApplication)
        {
            _touristReservationIncludeApplication = touristReservationIncludeApplication;
        }
        
        [HttpPost("post")]
        public async Task<IActionResult>Post([FromBody] ReservationIncludeDto touristReservationIncludeDto)
        {
            try
            {
                if (touristReservationIncludeDto == null)
                    return BadRequest();
                var response = await _touristReservationIncludeApplication.Add(touristReservationIncludeDto);
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
        public async Task<IActionResult> Update([FromBody] ReservationIncludeDto touristReservationIncludeDto)
        {
            if (touristReservationIncludeDto == null)
                return BadRequest();
            var response = await _touristReservationIncludeApplication.Update(touristReservationIncludeDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("Delete/{id}/{idReservation}")]
        public async Task<IActionResult> Delete(int id, int idReservation)
        {
            var response = await _touristReservationIncludeApplication.Delete(id, idReservation);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("Get/{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var response = await _touristReservationIncludeApplication.Get(Id);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
        [HttpGet("GetByReservationId/{id}")]
        public async Task<IActionResult> GetByReservationId(int id)
        {
            var response = await _touristReservationIncludeApplication.GetByReservationId(id);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _touristReservationIncludeApplication.GetAll();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }   

    }
    
}
