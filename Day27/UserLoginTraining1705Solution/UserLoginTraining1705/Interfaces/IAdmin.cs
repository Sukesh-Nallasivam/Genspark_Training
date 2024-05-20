using RequestTracker.Models;

namespace RequestTracker.Interfaces
{
    public interface IAdmin
    {
        public Task<Request> AddRequest(string RequestDescription,int UserID);
        public Task<Request> GetRequest(int UserID);
        public Task<IEnumerable<Request>> GetAllRequests();
        public Task<Solution> AddSolution(String Solutiondescrition);
    }
}
