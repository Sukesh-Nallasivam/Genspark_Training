using PizzaStore.Contexts;
using PizzaStore.Interfaces;
using PizzaStore.Models;

namespace PizzaStore.Repositories
{
    public class UserRepository : IRepository<int, UserAccount>
    {
        private readonly PizzaStoreDBContext _dbContext;

        public UserRepository(PizzaStoreDBContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public async Task<UserAccount> Add(UserAccount entity)
        {
            var result=await _dbContext.userAccounts.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public Task<UserAccount> Delete(int key)
        {
            throw new NotImplementedException();
        }

        public async Task<UserAccount> Get(int key)
        {
            var GetUserById = await _dbContext.userAccounts.FindAsync(key);
            if(GetUserById == null)
            {
                throw new NotImplementedException();
            }
            return GetUserById;
        }

        public Task<IEnumerable<UserAccount>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<UserAccount> Update(UserAccount entity)
        {
            var existingUser = await _dbContext.userAccounts.FindAsync(entity.UserId);
            if (existingUser == null)
            {
                throw new Exception("User not found");
            }

            existingUser.status = entity.status;

            _dbContext.userAccounts.Update(existingUser);
            await _dbContext.SaveChangesAsync();

            return existingUser;

        }
    }
}
