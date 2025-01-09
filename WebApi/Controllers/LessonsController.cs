using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonsController : ControllerBase
    {
        ILessonService _lessonService;
        public LessonsController(ILessonService lessonService) {
            _lessonService = lessonService;
        }
       [HttpGet("getAll")]
       public IActionResult GetAll()
        {
            var data = _lessonService.GetAll();
            if (data.Success)
            {
                return Ok(data);
            }
            return BadRequest();
        }
        [HttpGet("getById")]
        public IActionResult GetById(int id) 
        {
            var data = _lessonService.GetById(id);
            if (data.Success)
            {
                return Ok(data);
            }
            return BadRequest(data);
        }
        [HttpPost("add")]
        public IActionResult Add(Lesson lesson)
        {
            var data = _lessonService.Add(lesson);
            if (data.Success)
            {
                return Ok(data);
            }
            return BadRequest(data); 
            
        }
        [HttpPut("update")]
        public IActionResult Update(Lesson lesson) 
        {
            var data = _lessonService.Update(lesson);
            if (data.Success)
            {
                return Ok(data.Message);
            }
            return BadRequest(data.Message);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(Lesson lesson) 
        {
            var data = _lessonService.Delete(lesson);
            if (data.Success)
            {
                return Ok(data.Message);
            }
            return BadRequest(data.Message);
        }
        


    }
}
