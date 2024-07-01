using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KolonPullThroughErkekController : ControllerBase
    {
        IKolonPullThroughErkekService _kolonpullthrougherkekService;

        public KolonPullThroughErkekController(IKolonPullThroughErkekService kolonpullthrougherkekService)
        {
            _kolonpullthrougherkekService = kolonpullthrougherkekService;
        }

        [HttpGet("GetAllKolonPullThroughErkek")]
        public IActionResult GetAll()
        {
            try
            {
                var result = _kolonpullthrougherkekService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("GetByIdKolonPullThroughErkek")]
        public IActionResult GetById(int id)
        {
            try
            {
                var result = _kolonpullthrougherkekService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("KolonPullThroughErkekDeleteById")]
        public IActionResult Delete(int id)
        {
            try
            {
                _kolonpullthrougherkekService.DeleteById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("KolonPullThroughErkekDelete")]
        public IActionResult Deleteaaa(KolonPullThroughErkek kolonpullthrougherkek)
        {
            try
            {
                _kolonpullthrougherkekService.Delete(kolonpullthrougherkek);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost("KolonPullThroughErkekAdd")]
        public IActionResult Add(KolonPullThroughErkek kolonpullthrougherkek)
        {
            try
            {
                _kolonpullthrougherkekService.Add(kolonpullthrougherkek);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut("KolonPullThroughErkekUpdate")]
        public IActionResult Update(KolonPullThroughErkek kolonpullthrougherkek)
        {
            try
            {
                _kolonpullthrougherkekService.Update(kolonpullthrougherkek);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

    }
}
