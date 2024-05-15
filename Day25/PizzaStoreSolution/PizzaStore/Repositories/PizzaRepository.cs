using PizzaStore.Interfaces;
using PizzaStore.Models;

namespace PizzaStore.Repositories
{
    public class PizzaRepository : IRepository<int, Pizza>
    {
        public Task<Pizza> Add(Pizza entity)
        {
            throw new NotImplementedException();
        }

        public Task<Pizza> Delete(int key)
        {
            throw new NotImplementedException();
        }

        public Task<Pizza> Get(int key)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Pizza>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Pizza> Update(Pizza entity)
        {
            throw new NotImplementedException();
        }
    }
}
