using PizzaStore.Models;

namespace PizzaStore.Interfaces
{
    public interface ICustomerService
    {
        public Task<IEnumerable<Pizza>> GetAllAsync();
        public Task<IEnumerable<Pizza>> GetAvailablePizzasAsync();
        public Task<Customer> GetCustomerDetails(string customerId);
    }
}
