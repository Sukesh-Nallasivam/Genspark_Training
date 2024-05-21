using PizzaStore.Contexts;
using PizzaStore.Interfaces;
using PizzaStore.Models;

namespace PizzaStore.Repositories
{
    public class CustomerRepository : IRepository<int, Customer>
    {
        private readonly PizzaStoreDBContext _dbContext;

        public CustomerRepository(PizzaStoreDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public async Task<Customer> Add(Customer entity)
        {
            var addedEntity = await _dbContext.customers.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return addedEntity.Entity;
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
