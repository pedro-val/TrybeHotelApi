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
        public IActionResult GetUsers(){
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Add([FromBody] UserDtoInsert user)
        {
                        try
            {
                var addUser = new User
                {
                    Name = user.Name,
                    Email = user.Email,
                    Password = user.Password,
                    UserType = "client"
                };

                var addedUser = _repository.Add(user);

                var userDtoResponse = new UserDto
                {
                    UserId = addedUser.UserId,
                    Name = addedUser.Name,
                    Email = addedUser.Email,
                    UserType = addedUser.UserType
                };

                return CreatedAtAction(nameof(GetUsers), userDtoResponse);
            }
            catch (ArgumentException e)
            {
                return Conflict(e.Message);
            }
        }
    }
}