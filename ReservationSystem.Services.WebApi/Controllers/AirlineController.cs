using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReservationSystem.Application.DTO;
using ReservationSystem.Application.Interface;
using System.Threading.Tasks;

namespace ReservationSystem.Services.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AirlineController : Controller
    {
        private readonly IAirlineApplication _airlineApplication;
        public AirlineController(IAirlineApplication airlineApplication)
        {
            _airlineApplication = airlineApplication;
        }
        
        [HttpPost("post")]
        public async Task<IActionResult>Post([FromBody] AirlineDto airlineDto)
        {
            try
            {
                if (airlineDto == null)
                    return BadRequest();
                var response = await _airlineApplication.Add(airlineDto);
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
        public async Task<IActionResult> Update( [FromBody]AirlineDto airlineDto)
        {
            if (airlineDto == null)
                return BadRequest();
            var response = await _airlineApplication.Update(airlineDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _airlineApplication.Delete(id);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _airlineApplication.Get(id);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _airlineApplication.GetAll();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

      
    }

    
}
