using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaStore.Interfaces;
using PizzaStore.Models.DTO;
using System.Threading.Tasks;

namespace PizzaStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(IUserService userService, ILogger<CustomerController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(CustomerRegisterDTO customerRegisterDTO)
        {
            try
            {
                var customer = await _userService.CustomerRegister(customerRegisterDTO);
                _logger.LogInformation("Customer registered, email: {Email}", customerRegisterDTO.CustomerEmail);
                return Ok(customer);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while registering customer with email: {Email}", customerRegisterDTO.CustomerEmail);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDTO userLoginDTO)
        {
            try
            {
                var customer = await _userService.CustomerLogin(userLoginDTO);
                if (customer != null)
                {
                    _logger.LogInformation("Customer logged in successfully with Name: {CustomerName}", customer.CustomerName);
                    return Ok(customer);
                }
                _logger.LogWarning("Unauthorized login attempt");
                return Unauthorized();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while logging in customer");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
