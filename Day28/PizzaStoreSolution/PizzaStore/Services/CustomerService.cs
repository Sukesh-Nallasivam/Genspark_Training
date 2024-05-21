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
        public async Task<IEnumerable<Pizza>> GetAllAsync()
        {
            try
            {
                var allPizzas = await _pizzaRepository.GetAll();
                if (allPizzas == null)
                {
                    throw new EmptyDataBaseException("No pizza");
                }
                else
                {
                    return allPizzas;
                }
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<Pizza>();
            }
            

        }

        public async Task<IEnumerable<Pizza>> GetAvailablePizzasAsync()
        {
            try
            {
                
                var allPizzas = await _pizzaRepository.GetAll();

                
                var availablePizzas = allPizzas.Where(pizza => pizza.AvailabilityStatus);

                return availablePizzas;
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"An error occurred while retrieving available pizzas: {ex.Message}");
                throw;
            }
        }

        public Task<Customer> GetCustomerDetails(string customerId)
        {
            throw new NotImplementedException();
        }
    }
}
