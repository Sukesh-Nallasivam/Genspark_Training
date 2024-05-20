using UserLoginTraining1705.Models.DTO;
using UserLoginTraining1705.Models;
using RequestTracker.Models.DTO;
namespace UserLoginTraining1705.Interfaces
{
    public interface IUser
    {
        public Task<User> AddUser(UserDTO userDto);
        public Task<User> UpdateUser(User user);
        public Task<bool> DeleteUser(int UserId);
        public Task<User> GetUser(int UserId);
        public Task<LoginReturnDTO> LoginUser(string Email, string Password);
    }
}
