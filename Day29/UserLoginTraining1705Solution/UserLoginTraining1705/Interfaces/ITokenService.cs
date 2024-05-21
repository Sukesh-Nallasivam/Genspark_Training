using UserLoginTraining1705.Models;

namespace RequestTracker.Interfaces
{
    public interface ITokenService
    {
        public string GenerateToken(User user);
    }
}
