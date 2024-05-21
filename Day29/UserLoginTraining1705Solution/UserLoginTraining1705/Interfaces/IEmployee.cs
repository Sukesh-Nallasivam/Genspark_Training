using RequestTracker.Models;

namespace RequestTracker.Interfaces
{
    public interface IEmployee
    {
        public Task<Request> AddRequest(string RequestDescription);
        public Task<Solution> GetSolution(int RequestID);
        public Task<Solution> GetUserRequest(int UserId);
    }
}
