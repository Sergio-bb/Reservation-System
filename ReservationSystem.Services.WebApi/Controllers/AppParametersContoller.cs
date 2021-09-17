using Microsoft.AspNetCore.Mvc;
using ReservationSystem.Application.DTO;
using ReservationSystem.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystem.Services.WebApi.Controllers
{   //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AppParametersContoller : Controller
    {
        private readonly IAppParametersApplication _appParapetersApplication;
        public AppParametersContoller (IAppParametersApplication appParametersApplication)
        {
            _appParapetersApplication = appParametersApplication;
        }
        [HttpPost("Post")]
        public async Task<IActionResult> Post([FromBody] AppParametersDto appParametersDto)
        {
            try
            {
                if (appParametersDto == null)
                    return BadRequest();
                var response = await _appParapetersApplication.Add(appParametersDto);
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
        public async Task<IActionResult> Update([FromBody] AppParametersDto appParametersDto)
        {
            if (appParametersDto == null)
                return BadRequest();
            var response = await _appParapetersApplication.Update(appParametersDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _appParapetersApplication.Delete(id);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("Get/{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var response = await _appParapetersApplication.Get(Id);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _appParapetersApplication.GetAll();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAllByCode/{code}")]
        public async Task<IActionResult> GetAllByCode(string code)
        {
            if (string.IsNullOrEmpty(code))
                return BadRequest();
            var response = await _appParapetersApplication.GetAllByCode(code);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
    }
}

