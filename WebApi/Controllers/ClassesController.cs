using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{

    [Route("api/[controller]")] 
    [ApiController]
    public class ClassesController : ControllerBase
    {
        IClassService _classService;
        public ClassesController(IClassService classService)
        {
            _classService = classService;
        }
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var data = _classService.GetAll();
            if (data.Success)
            {
                return Ok(data);
            }
            return BadRequest();
        }
        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var data = _classService.GetById(id);
            if (data.Success)
            {
                return Ok(data);
            }
            return BadRequest(data);
        }
        [HttpPost("add")]
        public IActionResult Add(Class class1)
        {
            var data = _classService.Add(class1);
            if (data.Success)
            {
                return Ok(data);
            }
            return BadRequest(data);

        }
        [HttpPost("addfakee")]
        public IActionResult AddFake()
        {
            for (int i = 0; i < 25; i++)
            {
                _classService.Add(new Class { Grade = i, Letter = "A" + i.ToString() });

            }
                return Ok();
        

        }
        [HttpPut("update")]
        public IActionResult Update(Class class1)
        {
            var data = _classService.Update(class1);
            if (data.Success)
            {
                return Ok(data.Message);
            }
            return BadRequest(data.Message);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(Class class1)
        {
            var data = _classService.Delete(class1);
            if (data.Success)
            {
                return Ok(data.Message);
            }
            return BadRequest(data.Message);
        }



    }
}
