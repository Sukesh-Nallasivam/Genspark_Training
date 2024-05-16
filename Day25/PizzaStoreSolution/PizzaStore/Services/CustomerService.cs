using PizzaStore.Interfaces;
using PizzaStore.Models;

namespace PizzaStore.Services
{
    public class CustomerService:ICustomerService
    {
        public CustomerService() { }

        public Task<IEnumerable<Pizza>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Pizza>> GetAvailablePizzas()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerDetails(string customerId)
        {
            throw new NotImplementedException();
        }
    }
}
