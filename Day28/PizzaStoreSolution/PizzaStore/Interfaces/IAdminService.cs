using PizzaStore.Models;

namespace PizzaStore.Interfaces
{
    public interface IAdminService
    {
        public Task<Pizza> UpdatePizza(bool Availability);
        public Task<Pizza> AddPizza(Pizza pizza);
        public Task<bool> UpdateCustomerStatud(int userId);
    }
}
