using PizzaStore.Interfaces;
using PizzaStore.Models;

namespace PizzaStore.Services
{
    public class AdminService : IAdminService
    {

        private readonly IRepository<int, Customer> _customerRepository;
        private readonly IRepository<int, UserAccount> _userAccountRepository;
        private readonly IRepository<int, Admin> _adminRepository;

        public AdminService(IRepository<int, Customer> customerRepository, IRepository<int, UserAccount> userAccountRepository, IRepository<int, Admin> adminRepository)
        {
            _customerRepository = customerRepository;
            _userAccountRepository = userAccountRepository;
            _adminRepository = adminRepository;
        }
        public Task<Pizza> AddPizza(Pizza pizza)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateCustomerStatud(int userId)
        {
            var UserDb = await _userAccountRepository.Get(userId);
            if(UserDb == null)
            {
                throw new NotFoundException("no user found or not registered");
            }
            else if (UserDb.status == "false")
            {
                UserDb.status = "true";
                try
                {
                    await _userAccountRepository.Update(UserDb);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return false;
        }

        public Task<Pizza> UpdatePizza(bool Availability)
        {
            throw new NotImplementedException();
        }
    }
}
