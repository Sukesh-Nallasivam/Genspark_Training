using Microsoft.EntityFrameworkCore;
using UserLoginTraining1705.Context;
using UserLoginTraining1705.Exceptions;
using UserLoginTraining1705.Interfaces;
using UserLoginTraining1705.Models;

namespace UserLoginTraining1705.Repositories
{
    public class UserRepository : IRepository<int, User>
    {
        private readonly UserLoginContext _context;

        public UserRepository(UserLoginContext context)
        {
            _context = context;
        }

        public async Task<User> Add(User entity)
        {
            try
            {
                await _context.users.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new UnableToPerformWithDBException("Unable to add User entity");
            }
            return entity;
        }

        public Task<User> Delete(int key)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Get(int key)
        {
            try
            {
                var entity = await _context.users.FindAsync(key);

                return entity;
            }
            catch (Exception ex)
            {
                throw new UnableToPerformWithDBException("Unable to get User entity");
            }
            
        }
        public async Task<User> GetUserByMail(string Email)
        {
            try
            {
                var entity= await _context.users.FirstOrDefaultAsync(u => u.UserEmail == Email);
                if (entity == null) 
                    throw new UnableToPerformWithDBException("User not found");
                return entity;
            }
            catch (Exception ex)
            {
                throw new UnableToPerformWithDBException("Unable to get User Email");
            }

        }
        public Task<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<User> Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
