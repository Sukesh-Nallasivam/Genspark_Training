using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RequestTrackerModelLibrary;

namespace RequestTrackerBLLAdmin
{
    public interface IAdminOperation
    {
        //Raise Request
        //View Request Status(All Requests)
        //View Solutions(All Solutions)
        //Give Feedback(Only for request raised by them)
        //Respond to Solution(Only for request raised by them)
        //Provide Solution
        //Mark Request as Closed
        //View Feedbacks(Only feedbacks given to them)

        public Task<Request> RaiseRequest(Employee employee,String RequestInput);

        public Task<IEnumerable<Request>> ViewAllRequests();

        public Task<IEnumerable<RequestSolution>> ViewAllSolutions();

        public Task<SolutionFeedback> GiveFeedback(int requestId, string feedbackDetails);

        public Task<SolutionFeedback> RespondToSolution(int solutionId, string responseDetails);

        public Task<RequestSolution> ProvideSolution(int requestId, string solutionDetails, Employee employee);

        public Task<bool> MarkRequestAsClosed(string requestId);

        public Task<IEnumerable<SolutionFeedback>> ViewFeedbacks();
    }
}
