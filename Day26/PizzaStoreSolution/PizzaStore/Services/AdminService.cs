using PizzaStore.Interfaces;
using PizzaStore.Models;

namespace PizzaStore.Services
{
    public class AdminService : IAdminService
    {
        public Task<Pizza> AddPizza(Pizza pizza)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCustomerStatud(bool status)
        {
            throw new NotImplementedException();
        }

        public Task<Pizza> UpdatePizza(bool Availability)
        {
            throw new NotImplementedException();
        }
    }
}
