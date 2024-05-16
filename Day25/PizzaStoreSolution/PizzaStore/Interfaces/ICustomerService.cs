using PizzaStore.Models;

namespace PizzaStore.Interfaces
{
    public interface ICustomerService
    {
        public Task<IEnumerable<Pizza>> GetAll();
        public Task<IEnumerable<Pizza>> GetAvailablePizzas();
        public Task<Customer> GetCustomerDetails(string customerId);
    }
}
