using Microsoft.AspNetCore.Mvc;
using NghiaVoBlog.Data;
using NghiaVoBlog.Dto.User;
using NghiaVoBlog.Models;
using NghiaVoBlog.Repository;

namespace NghiaVoBlog.Controllers
{ 
    [ApiController]
    [Route("api/[controller]")]
    public class UserController:ControllerBase
    {
        private readonly UserRepository _userRepository ;
        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpPost]
         public IActionResult AddUser(CreateUserDto CreateUserDto)
        {
            if (ModelState.IsValid)
            {
            var user = new User()
                {
                    DisplayName =CreateUserDto.DisplayName,
                    Email =CreateUserDto.Email,
                    Phone =CreateUserDto.Phone,
                    Address =CreateUserDto.Address,
                    DateOfBirth = CreateUserDto.DateOfBirth
                };
                var createUser = _userRepository.InsertUser(user);
            return Ok(createUser);

            }
            else{
                return BadRequest(ModelState.ErrorCount);
            }
        }
    }
}