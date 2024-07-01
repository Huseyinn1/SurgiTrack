using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AntiRefluController : ControllerBase
    {
        IAntiRefluService _antirefluService;

        public AntiRefluController(IAntiRefluService antirefluService)
        {
            _antirefluService = antirefluService;
        }

        [HttpGet("GetAllAntiReflu")]
        public IActionResult GetAll()
        {
            try
            {
                var result = _antirefluService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("GetByIdAntiReflu")]
        public IActionResult GetById(int id)
        {
            try
            {
                var result = _antirefluService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("AntiRefluDeleteById")]
        public IActionResult Delete(int id)
        {
            try
            {
                _antirefluService.DeleteById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("AntiRefluDelete")]
        public IActionResult Deleteaaa(AntiReflu antireflu)
        {
            try
            {
                _antirefluService.Delete(antireflu);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost("AntiRefluAdd")]
        public IActionResult Add(AntiReflu antireflu)
        {
            try
            {
                _antirefluService.Add(antireflu);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut("AntiRefluUpdate")]
        public IActionResult Update(AntiReflu antireflu)
        {
            try
            {
                _antirefluService.Update(antireflu);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

    }
}
