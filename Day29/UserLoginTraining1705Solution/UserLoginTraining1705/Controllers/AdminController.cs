using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RequestTracker.Interfaces;
using RequestTracker.Models;
using UserLoginTraining1705.Exceptions;

namespace RequestTracker.Controllers
{
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    [ApiController]
    
    public class AdminController : ControllerBase
    {
        private readonly IAdmin _admin;

        public AdminController(IAdmin admin) 
        {
            _admin = admin;
        }
        [HttpGet("GetRequests")]
        public async Task<IActionResult> GetAllRequests()
        {
            try
            {
                var GetRequest = await _admin.GetAllRequests();
                return Ok(GetRequest);
            }
            catch(Exception ex)
            {
                throw new UnableToPerformWithDBException("No request");
            }
            return BadRequest(404);
        }
    }
}
