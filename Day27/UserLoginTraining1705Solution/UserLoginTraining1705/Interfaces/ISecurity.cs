using UserLoginTraining1705.Models;

namespace UserLoginTraining1705.Interfaces
{
    public interface ISecurity
    {
        public Task<Security> AddUserSecurity(Security security);
        
    }
}
