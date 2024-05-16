using PizzaStore.Interfaces;
using PizzaStore.Models;
using PizzaStore.Models.DTO;

namespace PizzaStore.Services
{
    public class LoginService : IUserService
    {
        private readonly IRepository<int,Customer> _customerRepository;
        private readonly IRepository<int,UserAccount> _userAccountRepository;
        private readonly IRepository<int, Admin> _adminRepository;

        public LoginService(IRepository<int, Customer> customerRepository, IRepository<int, UserAccount> userAccountRepository, IRepository<int, Admin> adminRepository)
        {
            _customerRepository = customerRepository;
            _userAccountRepository = userAccountRepository;
            _adminRepository = adminRepository;
        }

        public Task<Admin> AdminLogin(AdminLoginDTO adminLoginDTO)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> CustomerLogin(UserLoginDTO userLoginDTO)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> CustomerRegister(CustomerRegisterDTO customerRegisterDTO)
        {
            throw new NotImplementedException();
        }
    }
}
