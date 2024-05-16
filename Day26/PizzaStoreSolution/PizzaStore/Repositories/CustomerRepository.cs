using PizzaStore.Interfaces;
using PizzaStore.Models;

namespace PizzaStore.Repositories
{
    public class CustomerRepository : IRepository<int, Customer>
    {
        public Task<Customer> Add(Customer entity)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> Delete(int key)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> Get(int key)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
