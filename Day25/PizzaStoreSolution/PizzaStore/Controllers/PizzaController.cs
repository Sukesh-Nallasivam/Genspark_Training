using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaStore.Interfaces;
using System.Threading.Tasks;

namespace PizzaStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly ICustomerService _pizzaService;

        public PizzaController(ICustomerService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        [HttpGet("GetAvailable")]
        public async Task<IActionResult> GetPizzas()
        {
            var pizzas = await _pizzaService.GetAvailablePizzasAsync();
            return Ok(pizzas);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllPizzas()
        {
            var allPizzas = await _pizzaService.GetAllAsync();
            return Ok(allPizzas);
        }
    }
}
