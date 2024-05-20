using UserLoginTraining1705.Interfaces;
using UserLoginTraining1705.Models;
using UserLoginTraining1705.Repositories;

namespace UserLoginTraining1705.Services
{
    public class SecurityService : ISecurity
    {
        private IRepository<int, User> _userRepository;
        private IRepository<int, Security> _securityRepository;

        public SecurityService(IRepository<int, User> userRepository, IRepository<int, Security> securityRepository)
        {
            _userRepository = userRepository;
            _securityRepository = securityRepository;
        }

        public Task<Security> AddUserSecurity(Security security)
        {
            throw new NotImplementedException();
        }
    }
}
