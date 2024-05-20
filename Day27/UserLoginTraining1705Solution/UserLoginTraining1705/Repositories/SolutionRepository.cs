using RequestTracker.Models;
using UserLoginTraining1705.Interfaces;

namespace RequestTracker.Repositories
{
    public class SolutionRepository : IRepository<int, Solution>
    {
        public Task<Solution> Add(Solution entity)
        {
            throw new NotImplementedException();
        }

        public Task<Solution> Delete(int key)
        {
            throw new NotImplementedException();
        }

        public Task<Solution> Get(int key)
        {
            throw new NotImplementedException();
        }

        public Task<Solution> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Solution> GetUserByMail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Solution> Update(Solution entity)
        {
            throw new NotImplementedException();
        }
    }
}
