using PizzaStore.Interfaces;
using PizzaStore.Models;
using PizzaStore.Repositories;

namespace PizzaStore.Services
{
    public class CustomerService:ICustomerService
    {
        private readonly PizzaRepository _pizzaRepository;
        public CustomerService(PizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository ?? throw new ArgumentNullException(nameof(pizzaRepository));
        }
        public Task<IEnumerable<Pizza>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Pizza>> GetAvailablePizzasAsync()
        {
            try
            {
                // Retrieve all pizzas from the repository
                var allPizzas = await _pizzaRepository.GetAll();

                // Filter only the pizzas that are available (AvailabilityStatus == true)
                var availablePizzas = allPizzas.Where(pizza => pizza.AvailabilityStatus);

                return availablePizzas;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                Console.WriteLine($"An error occurred while retrieving available pizzas: {ex.Message}");
                throw; // Rethrow the exception or return an empty enumerable based on your error handling strategy
            }
        }

        public Task<Customer> GetCustomerDetails(string customerId)
        {
            throw new NotImplementedException();
        }
    }
}
