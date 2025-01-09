using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        IStudentService _studentService;
        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var data = _studentService.GetAll();
            if (data.Success)
            {
                return Ok(data);
            }
            return BadRequest();
        }
        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var data = _studentService.GetById(id);
            if (data.Success)
            {
                return Ok(data);
            }
            return BadRequest(data);
        }
        [HttpPost("add")]
        public IActionResult Add(Student student)
        {
            var data = _studentService.Add(student);
            if (data.Success)
            {
                return Ok(data);
            }
            return BadRequest(data);

        }
        [HttpPut("update")]
        public IActionResult Update(Student student)
        {
            var data = _studentService.Update(student);
            if (data.Success)
            {
                return Ok(data.Message);
            }
            return BadRequest(data.Message);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(Student student)
        {
            var data = _studentService.Delete(student);
            if (data.Success)
            {
                return Ok(data.Message);
            }
            return BadRequest(data.Message);
        }
        [HttpPost("addStuWithUser")]
        public IActionResult AddStuWithUser(StuWithUser stuWithUser)
        {
            var data = _studentService.AddStuWithUser(stuWithUser);
            if (data.Success)
            {
                return Ok(data.Message);
            }
            return BadRequest(data.Message);
        }
    }
}
