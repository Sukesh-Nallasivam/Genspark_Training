using PizzaStore.Models;
using PizzaStore.Models.DTO;

namespace PizzaStore.Interfaces
{
    public interface IUserService
    {
        public Task<Customer> CustomerLogin(UserLoginDTO userLoginDTO);
        public Task<Admin> AdminLogin(AdminLoginDTO adminLoginDTO);
        public Task<Customer> CustomerRegister(CustomerRegisterDTO customerRegisterDTO);
    }
}
