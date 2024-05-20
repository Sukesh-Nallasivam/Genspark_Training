using Microsoft.AspNetCore.Mvc;
using UserLoginTraining1705.Exceptions;
using UserLoginTraining1705.Interfaces;
using UserLoginTraining1705.Models;
using UserLoginTraining1705.Models.DTO;

namespace UserLoginTraining1705.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLoginController : ControllerBase
    {
        private IUser _user;

        public UserLoginController(IUser user)
        {
            _user = user;
        }
        [HttpPut("RegisterUser")]
        public async Task<ActionResult<UserDTO>> RegisterUser(UserDTO userDTO)
        {
            
            try
            {
                var register = await _user.AddUser(userDTO);
                return Ok(register);
            }
            catch (Exception ex)
            {
                throw new ErrorAddingUserException("User cannot be added");
            }
            return BadRequest(404);
        }

        [HttpGet("LoginUser")]
        public async Task<ActionResult<SecurityDTO>> LoginUser(string Email,String Password)
        {
            try
            {
                var Login = await _user.LoginUser(Email,Password);
                return Ok(Login);
            }
            catch (Exception ex)
            {
                throw new WrongCredentialsException("Invalid email or passowrd");
            }
        }

    }
}
