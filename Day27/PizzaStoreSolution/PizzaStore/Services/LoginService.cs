using PizzaStore.Exceptions;
using PizzaStore.Interfaces;
using PizzaStore.Models;
using PizzaStore.Models.DTO;
using PizzaStore.Repositories;
using System.Security.Cryptography;
using System.Text;

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

        public async Task<Admin> AdminLogin(AdminLoginDTO adminLoginDTO)
        {
            var adminDb = await _adminRepository.Get(adminLoginDTO.AdminId);
            if(adminDb == null)
            {
                throw new UnauthorizedUserException("Invalid username or password");
            }
            HMACSHA512 hMACSHA = new HMACSHA512(adminDb.AdminPasswrd);
            var encrypterPass = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(adminLoginDTO.AdminPassword));
            bool isPasswordSame = ComparePassword(encrypterPass, adminDb.AdminPasswrd);
            if (isPasswordSame)
            {
                var employee = await _adminRepository.Get(adminLoginDTO.AdminId);
                return employee;
            }
            throw new UnauthorizedUserException("Invalid username or password");
        }
        private bool ComparePassword(byte[] encrypterPass, byte[] password)
        {
            for (int i = 0; i < encrypterPass.Length; i++)
            {
                if (encrypterPass[i] != password[i])
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<Customer> CustomerLogin(UserLoginDTO userLoginDTO)
        {
            var userAccount = await _userAccountRepository.Get(userLoginDTO.CustomerId);
            if (userAccount == null)
            {
                throw new UnauthorizedUserException("Invalid username or password");
            }

            HMACSHA512 hMACSHA = new HMACSHA512(userAccount.PasswordSalt);
            var encryptedPass = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(userLoginDTO.CustomerPassword));
            bool isPasswordSame = ComparePassword(encryptedPass, userAccount.PasswordHashKey);
            if (isPasswordSame)
            {
                var customer = await _customerRepository.Get(userLoginDTO.CustomerId);
                if (customer == null)
                {
                    var employee = await _customerRepository.Get(userLoginDTO.CustomerId);
                    if (userAccount.status == "true")
                        return employee;
                    throw new UserNotActiveException("Your account is not activated");
                }
                return customer;
            }
            throw new UnauthorizedUserException("Invalid username or password");
        }

        public async Task<Customer> CustomerRegister(CustomerRegisterDTO customerRegisterDTO)
        {
            HMACSHA512 hMACSHA = new HMACSHA512();


            var customer = new Customer
            {
                CustomerId = customerRegisterDTO.CustomerId,
                CustomerName = customerRegisterDTO.CustomerName,
                CustomerEmail = customerRegisterDTO.CustomerEmail,
                
            };

            var CustomerResult= await _customerRepository.Add(customer);
            var userAccount = new UserAccount
            {
                CustomerId=CustomerResult.CustomerId,
                //Password=customerRegisterDTO.Password,
                PasswordHashKey = hMACSHA.ComputeHash(Encoding.UTF8.GetBytes(customerRegisterDTO.Password)),
                PasswordSalt = hMACSHA.Key
            };

            await _userAccountRepository.Add(userAccount);
            return customer;
        }

    }
}
