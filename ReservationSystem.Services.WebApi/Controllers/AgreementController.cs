using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReservationSystem.Application.DTO;
using ReservationSystem.Application.Interface;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ReservationSystem.Services.WebApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AgreementController : Controller
    {
        private readonly IAgreementApplication _agreementApplication;
       
        public AgreementController(IAgreementApplication agreementApplication)
        {
            _agreementApplication = agreementApplication;
        }

        [HttpPost("Post")]
        public async Task<IActionResult> Post([FromBody] AgreementDto agreementDto)
        {
            try
            {
                if (agreementDto == null)
                    return BadRequest();
                var response = await _agreementApplication.Add(agreementDto);
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
        public async Task<IActionResult> Update([FromBody] AgreementDto agreementDto)
        {
            if (agreementDto == null)
                return BadRequest();
            var response = await _agreementApplication.Update(agreementDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _agreementApplication.Delete(id);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("Get/{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var response = await _agreementApplication.Get(Id);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _agreementApplication.GetAll();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAllByCode/{code}")]
        public async Task<IActionResult> GetAllByCode(string code)
        {
            if (string.IsNullOrEmpty(code))
                return BadRequest();
            var response = await _agreementApplication.GetAllByCode(code);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
    }
}