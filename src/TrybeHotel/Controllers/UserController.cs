using Microsoft.AspNetCore.Mvc;
using TrybeHotel.Models;
using TrybeHotel.Repository;
using TrybeHotel.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace TrybeHotel.Controllers
{
    [ApiController]
    [Route("user")]

    public class UserController : Controller
    {
        private readonly IUserRepository _repository;
        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        [Authorize(Policy = "Admin")]
        public IActionResult GetUsers(){
            try
            {
                var users = _repository.GetUsers();
                return Ok(users);
                
            }
            catch (System.Exception e)
            {
                //object status deve ser 401
                return Unauthorized(new { message = e.Message });
            }
        }

        [HttpPost]
        public IActionResult Add([FromBody] UserDtoInsert user)
        {
            try
            {
                var addedUser = _repository.Add(user);
                return CreatedAtAction(nameof(GetUsers), addedUser);
            }
            catch (ArgumentException e)
            {
                return Conflict(new { message = e.Message });
            }
        }
    }
}