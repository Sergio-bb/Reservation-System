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
    public class IncludeController : Controller
    {
        private readonly IIncludeApplication _includeApplication;
        public IncludeController(IIncludeApplication includeApplication)
        {
            _includeApplication = includeApplication;
        }
        
        [HttpPost("post")]
        public async Task<IActionResult>Post([FromBody] IncludeDto includeDto)
        {
            try
            {
                if (includeDto == null)
                    return BadRequest();
                var response = await _includeApplication.Add(includeDto);
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
        public async Task<IActionResult> Update([FromBody] IncludeDto includeDto)
        {
            if (includeDto == null)
                return BadRequest();
            var response = await _includeApplication.Update(includeDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _includeApplication.Delete(id);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("Get/{Id}")]
        public async Task<IActionResult> Get(int Id)
        {
            var response = await _includeApplication.Get(Id);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _includeApplication.GetAll();
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAllByCode/{code}")]
        public async Task<IActionResult> GetAllByCode(string code)
        {
            if (string.IsNullOrEmpty(code))
                return BadRequest();
            var response = await _includeApplication.GetAllByCode(code);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
    }

    
}
