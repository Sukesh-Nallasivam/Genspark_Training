using RequestTracker.Models;
using UserLoginTraining1705.Interfaces;

namespace RequestTracker.Repositories
{
    public class RequestRepository : IRepository<int, Request>
    {
        public Task<Request> Add(Request entity)
        {
            throw new NotImplementedException();
        }

        public Task<Request> Delete(int key)
        {
            throw new NotImplementedException();
        }

        public Task<Request> Get(int key)
        {
            throw new NotImplementedException();
        }

        public Task<Request> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Request> GetUserByMail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Request> Update(Request entity)
        {
            throw new NotImplementedException();
        }
    }
}
