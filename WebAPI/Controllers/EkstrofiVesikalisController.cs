using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EkstrofiVesikalisController : ControllerBase
    {
        IEkstrofiVesikalisService _ekstrofivesikalisService;

        public EkstrofiVesikalisController(IEkstrofiVesikalisService ekstrofivesikalisService)
        {
            _ekstrofivesikalisService = ekstrofivesikalisService;
        }

        [HttpGet("GetAllEkstrofiVesikalis")]
        public IActionResult GetAll()
        {
            try
            {
                var result = _ekstrofivesikalisService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("GetByIdEkstrofiVesikalis")]
        public IActionResult GetById(int id)
        {
            try
            {
                var result = _ekstrofivesikalisService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("EkstrofiVesikalisDeleteById")]
        public IActionResult Delete(int id)
        {
            try
            {
                _ekstrofivesikalisService.DeleteById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("EkstrofiVesikalisDelete")]
        public IActionResult Deleteaaa(EkstrofiVesikalis ekstrofivesikalis)
        {
            try
            {
                _ekstrofivesikalisService.Delete(ekstrofivesikalis);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost("EkstrofiVesikalisAdd")]
        public IActionResult Add(EkstrofiVesikalis ekstrofivesikalis)
        {
            try
            {
                _ekstrofivesikalisService.Add(ekstrofivesikalis);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut("EkstrofiVesikalisUpdate")]
        public IActionResult Update(EkstrofiVesikalis ekstrofivesikalis)
        {
            try
            {
                _ekstrofivesikalisService.Update(ekstrofivesikalis);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

    }
}
