using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;
        public UsersController(IUserService userService) 
        {
            _userService = userService;
        }
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var data = _userService.GetAll();
            if (data.Success)
            {
                return Ok(data);
            }
            return BadRequest();
        }
        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var data = _userService.GetById(id);
            if (data.Success)
            {
                return Ok(data);
            }
            return BadRequest(data);
        }
        [HttpPost("add")]
        public IActionResult Add(User user)
        {
            var data = _userService.Add(user);
            if (data.Success)
            {
                return Ok(data);
            }
            return BadRequest(data);

        }
        [HttpPut("update")]
        public IActionResult Update(User user)
        {
            var data = _userService.Update(user);
            if (data.Success)
            {
                return Ok(data.Message);
            }
            return BadRequest(data.Message);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(User user)
        {
            var data = _userService.Delete(user);
            if (data.Success)
            {
                return Ok(data.Message);
            }
            return BadRequest(data.Message);
        }
        [HttpGet("getUser")]
        public IActionResult GetUser(string email,string password) 
        {
            var data = _userService.getUser(email,password);
            if (data.Success)
            {
                return Ok(data);
            }
            return BadRequest(data);
        }

    }
}
