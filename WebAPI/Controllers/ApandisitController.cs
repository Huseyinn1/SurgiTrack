using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApandisitController : ControllerBase
    {
        IApandisitService _apandisitService;

        public ApandisitController(IApandisitService apandisitService)
        {
            _apandisitService = apandisitService;
        }

        [HttpGet("GetAllApandisit")]
        public IActionResult GetAll()
        {
            try
            {
                var result = _apandisitService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpGet("GetByIdApandisit")]
        public IActionResult GetById(int id)
        {
            try
            {
                var result = _apandisitService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("ApandisitDeleteById")]
        public IActionResult Delete(int id)
        {
            try
            {
                _apandisitService.DeleteById(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpDelete("ApandisitDelete")]
        public IActionResult Deleteaaa(Apandisit apandisit)
        {
            try
            {
                _apandisitService.Delete(apandisit);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPost("ApandisitAdd")]
        public IActionResult Add(Apandisit apandisit)
        {
            try
            {
                _apandisitService.Add(apandisit);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

        [HttpPut("ApandisitUpdate")]
        public IActionResult Update(Apandisit apandisit)
        {
            try
            {
                _apandisitService.Update(apandisit);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }

    }
}
