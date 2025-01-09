using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        ITeacherService _teacherService;
        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var data = _teacherService.GetAll();
            if (data.Success)
            {
                return Ok(data);
            }
            return BadRequest();
        }
        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var data = _teacherService.GetById(id);
            if (data.Success)
            {
                return Ok(data);
            }
            return BadRequest(data);
        }
        [HttpPost("add")]
        public IActionResult Add(Teacher teacher)
        {
            var data = _teacherService.Add(teacher);
            if (data.Success)
            {
                return Ok(data);
            }
            return BadRequest(data);

        }
        [HttpPut("update")]
        public IActionResult Update(Teacher teacher)
        {
            var data = _teacherService.Update(teacher);
            if (data.Success)
            {
                return Ok(data.Message);
            }
            return BadRequest(data.Message);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(Teacher teacher)
        {
            var data = _teacherService.Delete(teacher);
            if (data.Success)
            {
                return Ok(data.Message);
            }
            return BadRequest(data.Message);
        }
        [HttpPost("addTeachWithUser")]
        public IActionResult AddTeachWithUser(TeachWithUser teachWithUser)
        {
            var data = _teacherService.AddTeachWithUser(teachWithUser);
            if (data.Success)
            {
                return Ok(data.Message);
            }
            return BadRequest(data.Message);
        }


    }
}
