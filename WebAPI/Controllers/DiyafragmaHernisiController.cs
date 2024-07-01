using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiyafragmaHernisiController : ControllerBase
    {
        IDiyafragmaHernisiService _diyafragmahernisiService;

        public DiyafragmaHernisiController(IDiyafragmaHernisiService diyafragmahernisiService)
        {
            _diyafragmahernisiService = diyafragmahernisiService;
        }

        [HttpGet("GetAllDiyafragmaHernisi")]
        public IActionResult GetAll()
        {
            try
            {
                var result = _diyafragmahernisiService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("GetByIdDiyafragmaHernisi")]
        public IActionResult GetById(int id)
        {
            try
            {
                var result = _diyafragmahernisiService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("DiyafragmaHernisiDeleteById")]
        public IActionResult Delete(int id)
        {
            try
            {
                _diyafragmahernisiService.DeleteById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("DiyafragmaHernisiDelete")]
        public IActionResult Deleteaaa(DiyafragmaHernisi diyafragmahernisi)
        {
            try
            {
                _diyafragmahernisiService.Delete(diyafragmahernisi);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost("DiyafragmaHernisiAdd")]
        public IActionResult Add(DiyafragmaHernisi diyafragmahernisi)
        {
            try
            {
                _diyafragmahernisiService.Add(diyafragmahernisi);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut("DiyafragmaHernisiUpdate")]
        public IActionResult Update(DiyafragmaHernisi diyafragmahernisi)
        {
            try
            {
                _diyafragmahernisiService.Update(diyafragmahernisi);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

    }
}
