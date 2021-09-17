using Microsoft.AspNetCore.Mvc;
using ReservationSystem.Application.DTO;
using ReservationSystem.Application.Interface;
using System.Threading.Tasks;

namespace ReservationSystem.Services.WebApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TouristReservationPassengerController : Controller
    {
        private readonly ITouristReservationPassengerApplication _touristReservationPassengerApplication;
        public TouristReservationPassengerController(ITouristReservationPassengerApplication touristReservationPassengerApplication)
        {
            _touristReservationPassengerApplication = touristReservationPassengerApplication;
        }
        
        [HttpPost("post")]
        public async Task<IActionResult>Post([FromBody] ReservationPassengerDto touristReservationPassengerDto)
        {
            try
            {
                if (touristReservationPassengerDto == null)
                    return BadRequest();
                var response = await _touristReservationPassengerApplication.Add(touristReservationPassengerDto);
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
        public async Task<IActionResult> Update([FromBody] ReservationPassengerDto touristReservationPassengerDto)
        {
            if (touristReservationPassengerDto == null)
                return BadRequest();
            var response = await _touristReservationPassengerApplication.Update(touristReservationPassengerDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetByReservationId/{id}")]
        public async Task<IActionResult> GetByReservationId(int id)
        {
            var response = await _touristReservationPassengerApplication.GetByReservationId(id);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _touristReservationPassengerApplication.Delete(id);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("Get/{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var response = await _touristReservationPassengerApplication.Get(Id);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
           
            var response = await _touristReservationPassengerApplication.GetAll();
                if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }      
    }    
}
