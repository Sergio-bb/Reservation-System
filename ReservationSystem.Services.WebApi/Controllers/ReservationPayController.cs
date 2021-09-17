using Microsoft.AspNetCore.Mvc;
using ReservationSystem.Application.DTO;
using ReservationSystem.Application.Interface;
using System.Threading.Tasks;

namespace ReservationSystem.Services.WebApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationPayController : Controller
    {
        private readonly IReservationPayApplication _reservationPayApplication;
        public ReservationPayController(IReservationPayApplication reservationPayApplication)
        {
            _reservationPayApplication = reservationPayApplication;
        }
        
        [HttpPost("post")]
        public async Task<IActionResult>Post([FromBody] ReservationPayDto reservationPayDto)
        {
            try
            {
                if (reservationPayDto == null)
                    return BadRequest();
                var response = await _reservationPayApplication.Add(reservationPayDto);
                if (response.IsSuccess)
                    return Ok(response);
                return BadRequest(response.Message);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex);
            }
        }         

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _reservationPayApplication.Get(id);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _reservationPayApplication.GetAll();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
        [HttpGet("GetByReservationId/{reservationId}")]
        public async Task<IActionResult> GetByReservationId(int reservationId)
        {
            var response = await _reservationPayApplication.GetByReservationId(reservationId);
            if (response.IsSuccess)
                return Ok(response);
            return BadRequest(response.Message);
        }
    }    
}
