using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalAtreziController : ControllerBase
    {
        IAnalAtreziService _analatreziService;

        public AnalAtreziController(IAnalAtreziService analatreziService)
        {
            _analatreziService = analatreziService;
        }

        [HttpGet("GetAllAnalAtrezi")]
        public IActionResult GetAll()
        {
            try
            {
                var result = _analatreziService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("GetByIdAnalAtrezi")]
        public IActionResult GetById(int id)
        {
            try
            {
                var result = _analatreziService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("AnalAtreziDeleteById")]
        public IActionResult Delete(int id)
        {
            try
            {
                _analatreziService.DeleteById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("AnalAtreziDelete")]
        public IActionResult Deleteaaa(AnalAtrezi analatrezi)
        {
            try
            {
                _analatreziService.Delete(analatrezi);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost("AnalAtreziAdd")]
        public IActionResult Add(AnalAtrezi analatrezi)
        {
            try
            {
                _analatreziService.Add(analatrezi);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut("AnalAtreziUpdate")]
        public IActionResult Update(AnalAtrezi analatrezi)
        {
            try
            {
                _analatreziService.Update(analatrezi);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

    }
}
