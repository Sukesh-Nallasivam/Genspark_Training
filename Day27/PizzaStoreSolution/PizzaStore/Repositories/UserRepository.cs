using PizzaStore.Interfaces;
using PizzaStore.Models;

namespace PizzaStore.Repositories
{
    public class UserRepository : IRepository<int, UserAccount>
    {
        public Task<UserAccount> Add(UserAccount entity)
        {
            throw new NotImplementedException();
        }

        public Task<UserAccount> Delete(int key)
        {
            throw new NotImplementedException();
        }

        public Task<UserAccount> Get(int key)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserAccount>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<UserAccount> Update(UserAccount entity)
        {
            throw new NotImplementedException();
        }
    }
}
