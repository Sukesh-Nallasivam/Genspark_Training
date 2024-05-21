using Microsoft.AspNetCore.Mvc;
using PizzaStore.Interfaces;

namespace PizzaStore.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AdminController:ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer(int UserId)
        {
            try
            {
                await _adminService.UpdateCustomerStatud(UserId);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
            return BadRequest();
        }
    }
}
