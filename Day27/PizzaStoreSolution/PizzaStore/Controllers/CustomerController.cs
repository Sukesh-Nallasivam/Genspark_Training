using Microsoft.AspNetCore.Mvc;
using PizzaStore.Interfaces;
using PizzaStore.Models.DTO;
using PizzaStore.Helpers;
using System.Threading.Tasks;

namespace PizzaStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly string _secretKey = "YourSuperSecretKey";

        public CustomerController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CustomerRegisterDTO customerRegisterDTO)
        {
            var customer = await _userService.CustomerRegister(customerRegisterDTO);
            return Ok(customer);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO userLoginDTO)
        {
            var customer = await _userService.CustomerLogin(userLoginDTO);
            if (customer != null)
            {
                return Ok(customer); 
            }
            return Unauthorized(); // 401
        }
    }
}
