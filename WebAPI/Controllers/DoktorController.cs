using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoktorController : ControllerBase
    {
        IDoktorService _doktorService;

        public DoktorController(IDoktorService doktorService)
        {
            _doktorService = doktorService;          
        }



        [HttpGet("GetAllDoktor")]
        public IActionResult GetAll()
        {
            try
            {
                var result = _doktorService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("GetByIdDoktor")]
        public IActionResult GetById(int id)
        {
            try
            {
                var result = _doktorService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("DoktorDeleteById")]
        public IActionResult Delete(int id)
        {
            try
            {
                _doktorService.DeleteById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("DoktorDelete")]
        public IActionResult Deleteaaa(Doktor doktor)
        {
            try
            {
                _doktorService.Delete(doktor);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost("DoktorAdd")]
        public IActionResult Add(Doktor doktor)
        {
            try
            {
                _doktorService.Add(doktor);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut("DoktorUpdate")]
        public IActionResult Update(Doktor doktor)
        {
            try
            {
                _doktorService.Update(doktor);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }



    }
}
