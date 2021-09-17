using Microsoft.AspNetCore.Mvc;
using ReservationSystem.Application.DTO;
using ReservationSystem.Application.Interface;
using System.Threading.Tasks;

namespace ReservationSystem.Services.WebApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : Controller
    {
        private readonly IHotelApplication _hotelApplication;
        public HotelController(IHotelApplication hotelApplication)
        {
            _hotelApplication = hotelApplication;
        }
        
        [HttpPost("post")]
        public async Task<IActionResult>Post([FromBody]  HotelDto hotelDto)
        {
            try
            {
                if (hotelDto == null)
                    return BadRequest();
                var response = await _hotelApplication.Add(hotelDto);
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
        public async Task<IActionResult> Update([FromBody] HotelDto hotelDto)
        {
            if (hotelDto == null)
                return BadRequest();
            var response = await _hotelApplication.Update(hotelDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _hotelApplication.Delete(id);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("Get/{Id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _hotelApplication.Get(id);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetByDestinationId/{id}")]
        public async Task<IActionResult> GetByDestinationId(int id)
        {
            var response = await _hotelApplication.GetByDestinationId(id);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _hotelApplication.GetAll();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

      
    }

    
}
