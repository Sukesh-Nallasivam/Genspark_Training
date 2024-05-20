using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using UserLoginTraining1705.Exceptions;
using UserLoginTraining1705.Interfaces;
using UserLoginTraining1705.Models;
using UserLoginTraining1705.Models.DTO;
using UserLoginTraining1705.Repositories;

namespace UserLoginTraining1705.Services
{
    public class UserService : IUser
    {
        private IRepository<int, User> _userRepository;
        private IRepository<int, Security> _securityRepository;

        public UserService(IRepository<int, User> userRepository, IRepository<int, Security> securityRepository)
        {
            _userRepository = userRepository;
            _securityRepository = securityRepository;
        }

        public async Task<User> AddUser(UserDTO userDto)
        {
            try
            {
                var AddingUser = new User()
                {
                    UserEmail = userDto.UserEmail,
                    UserName = userDto.UserName,
                    Role = userDto.Role
                };
                var result = await _userRepository.Add(AddingUser);
                
                //var UserID = await _userRepository.Get(result.UserId);
                var (PasswordByte, PasswordHashKey_) = PasswordHashing(userDto.Password);
                var AddingSecurity = new Security()
                {
                    UserId = AddingUser.UserId,
                    //HMACSHA512
                    Password = PasswordByte,
                    PasswordHashKey = PasswordHashKey_,
                    User=AddingUser
                    
                };

                await _securityRepository.Add(AddingSecurity);
            }
            catch (Exception ex)
            {
                throw new UnableToAddException("Unable to add");
            }
            return userDto;
            
        }
        
        public Task<bool> DeleteUser(int UserId)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUser(int UserId)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
        public byte[] ConvertToByte(string Password)
        {
            return Encoding.UTF8.GetBytes(Password);
        }
        public (byte[] PasswordByte,byte[] PasswordHashKey_) PasswordHashing(string Password)
        {
            HMACSHA512 hMACSHA512 = new HMACSHA512();
            var PasswordBytesHash= hMACSHA512.ComputeHash(ConvertToByte(Password));
            var key = hMACSHA512.Key;
            return (PasswordBytesHash,key);
        }


        public async Task<UserDTO> LoginUser(string Email,string Password)
        {
            try
            {           
                var getUser = await _userRepository.GetUserByMail(Email);
                if(getUser!=null)
                {
                    var getSecurity = await _securityRepository.Get(getUser.UserId);
                    if(getSecurity!=null)
                    {
                        var IspasswordSame = ComparePassword(Password, getSecurity.Password,getSecurity.PasswordHashKey);
                        if (IspasswordSame)
                        {
                            if(!getUser.AcitiveStatus)
                            {
                                throw new NotActiveException("Your account not activated");
                            }
                            else
                            {
                                return new UserDTO
                                {
                                    UserName = getUser.UserName,
                                    UserId = getUser.UserId,
                                    Role = getUser.Role
                                };
                            }
                            
                        }

                    }
                }
                throw new WrongCredentialsException("Invalid email or password");
            }
            catch (Exception ex)
            {
                throw new WrongCredentialsException("Invalid email or password");
            }
            
        }
        private bool ComparePassword(string password, byte[] storedPassword, byte[] key)
        {
            using (var hmac = new HMACSHA512(key))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedPassword[i]) return false;
                }
            }
            return true;
        }
    }
}
