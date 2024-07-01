using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmeliyatController : ControllerBase
    {
        IAmeliyatService _ameliyatService;

        public AmeliyatController(IAmeliyatService ameliyatService)
        {
            _ameliyatService = ameliyatService;
        }



        [HttpGet("GetAllAmeliyat")]
        public IActionResult GetAll()

        {
            try
            {
                var result = _ameliyatService.GetAll();
                return Ok(result);

            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("GetByIdAmeliyat")]
        public IActionResult GetById(int id)

        {

            try
            {
                var result = _ameliyatService.GetById(id);
                return Ok(result);
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("AmeliyatDeleteById")]
        public IActionResult Delete(int id)

        {
            try
            {
                _ameliyatService.DeleteById(id);
                return Ok();
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }

        }

        [HttpDelete("AmeliyatDelete")]
        public IActionResult Deleteaaa(Ameliyat ameliyat)

        {
            try
            {
                _ameliyatService.Delete(ameliyat);
                return Ok();
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }

        }

        [HttpPost("AmeliyatAdd")]
        public IActionResult Add(Ameliyat ameliyat)

        {
            try
            {
                _ameliyatService.Add(ameliyat);
                return Ok();
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }

        }

        [HttpPut("AmeliyatUpdate")]
        public IActionResult Update(Ameliyat ameliyat)

        {
            try
            {
                _ameliyatService.Update(ameliyat);
                return Ok();
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }

        }


    }
}