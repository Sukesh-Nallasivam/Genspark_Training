using RequestTrackerModelLibrary;

namespace RequestTrackerBLLUser
{
    public class UserOperation : IUserOperation
    {
        public Task<string> GiveFeedback(string requestId, string feedbackDetails)
        {
            throw new NotImplementedException();
        }

        public Task<string> RaiseRequest(Request request)
        {
            throw new NotImplementedException();
        }

        public Task<string> RespondToSolution(string requestId, string responseDetails)
        {
            throw new NotImplementedException();
        }

        public Task<string> ViewRequestStatus(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<SolutionFeedback>> ViewSolutions(string requestId)
        {
            throw new NotImplementedException();
        }
    }
}
