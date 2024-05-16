using Microsoft.EntityFrameworkCore;
using PizzaStore.Contexts;
using PizzaStore.Interfaces;
using PizzaStore.Models;

namespace PizzaStore.Repositories
{
    public class PizzaRepository : IRepository<int, Pizza>
    {
        private readonly PizzaStoreDBContext _dbContext;

        public PizzaRepository(PizzaStoreDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
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

        public async Task<IEnumerable<Pizza>> GetAll()
        {
            try
            {
                
                return await _dbContext.pizzas.ToListAsync();
            }
            catch (Exception ex)
            {
                
                Console.WriteLine($"An error occurred while retrieving all pizzas: {ex.Message}");
                throw; 
            }
        }

        public Task<Pizza> Update(Pizza entity)
        {
            throw new NotImplementedException();
        }
    }
}
