using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KolonPullThroughKadinController : ControllerBase
    {
        IKolonPullThroughKadinService _kolonpullthroughkadinService;

        public KolonPullThroughKadinController(IKolonPullThroughKadinService kolonpullthroughkadinService)
        {
            _kolonpullthroughkadinService = kolonpullthroughkadinService;
        }

        [HttpGet("GetAllKolonPullThroughKadin")]
        public IActionResult GetAll()
        {
            try
            {
                var result = _kolonpullthroughkadinService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("GetByIdKolonPullThroughKadin")]
        public IActionResult GetById(int id)
        {
            try
            {
                var result = _kolonpullthroughkadinService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("KolonPullThroughKadinDeleteById")]
        public IActionResult Delete(int id)
        {
            try
            {
                _kolonpullthroughkadinService.DeleteById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("KolonPullThroughKadinDelete")]
        public IActionResult Deleteaaa(KolonPullThroughKadin kolonpullthroughkadin)
        {
            try
            {
                _kolonpullthroughkadinService.Delete(kolonpullthroughkadin);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost("KolonPullThroughKadinAdd")]
        public IActionResult Add(KolonPullThroughKadin kolonpullthroughkadin)
        {
            try
            {
                _kolonpullthroughkadinService.Add(kolonpullthroughkadin);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut("KolonPullThroughKadinUpdate")]
        public IActionResult Update(KolonPullThroughKadin kolonpullthroughkadin)
        {
            try
            {
                _kolonpullthroughkadinService.Update(kolonpullthroughkadin);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

    }
}
