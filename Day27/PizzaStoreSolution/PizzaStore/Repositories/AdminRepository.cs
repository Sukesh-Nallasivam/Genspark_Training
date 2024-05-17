using PizzaStore.Interfaces;
using PizzaStore.Models;

namespace PizzaStore.Repositories
{
    public class AdminRepository : IRepository<int, Admin>
    {
        public Task<Admin> Add(Admin entity)
        {
            throw new NotImplementedException();
        }

        public Task<Admin> Delete(int key)
        {
            throw new NotImplementedException();
        }

        public Task<Admin> Get(int key)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Admin>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Admin> Update(Admin entity)
        {
            throw new NotImplementedException();
        }
    }
}
