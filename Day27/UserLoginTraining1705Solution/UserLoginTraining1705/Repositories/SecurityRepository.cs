using Microsoft.EntityFrameworkCore;
using UserLoginTraining1705.Context;
using UserLoginTraining1705.Exceptions;
using UserLoginTraining1705.Interfaces;
using UserLoginTraining1705.Models;

namespace UserLoginTraining1705.Repositories
{
    public class SecurityRepository : IRepository<int, Security>
    {
        
        private readonly UserLoginContext _context;
        public SecurityRepository(UserLoginContext context)
        {
            _context = context;
        }
        public async Task<Security> Add(Security entity)
        {
            try
            {
                await _context.securities.AddAsync(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new UnableToPerformWithDBException("Unable to add User entity");
            }
            return entity;
        }


        public Task<Security> Delete(int key)
        {
            throw new NotImplementedException();
        }

        public async Task<Security> Get(int key)
        {
            try
            {
                var security = await _context.securities.FindAsync(key);
                if(security == null)
                {
                    throw new WrongCredentialsException("Invalid");
                }
                return security;
            }
            catch (Exception ex)
            {
                throw new WrongCredentialsException("Invalid");
            }
            
        }

        public Task<Security> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Security> GetUserByMail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Security> Update(Security entity)
        {
            throw new NotImplementedException();
        }
    }
}
