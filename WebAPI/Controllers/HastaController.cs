using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HastaController : ControllerBase
    {
        IHastaService _hastaService;

        public HastaController(IHastaService hastaService)
        {
            _hastaService = hastaService;
        }




        [HttpGet("GetAllHasta")]
        public IActionResult GetAll()
        {
            try
            {
                var result = _hastaService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("GetByIdHasta")]
        public IActionResult GetById(int id)
        {
            try
            {
                var result = _hastaService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("HastaDeleteById")]
        public IActionResult Delete(int id)
        {
            try
            {
                _hastaService.DeleteById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("HastaDelete")]
        public IActionResult Deleteaaa(Hasta hasta)
        {
            try
            {
                _hastaService.Delete(hasta);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost("HastaAdd")]
        public IActionResult Add(Hasta hasta)
        {
            try
            {
                _hastaService.Add(hasta);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut("HastaUpdate")]
        public IActionResult Update(Hasta hasta)
        {
            try
            {
                _hastaService.Update(hasta);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }



    }
}
