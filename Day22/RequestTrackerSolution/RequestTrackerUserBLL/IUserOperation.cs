using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RequestTrackerModelLibrary;

namespace RequestTrackerBLLUser
{
    public interface IUserOperation
    {
        //Raise Request
        //View Request Status
        //View Solutions
        //Give Feedback
        //Respond to Solution

        Task<string> RaiseRequest(Request request);
        Task<string> ViewRequestStatus(string userId);
        Task<IList<SolutionFeedback>> ViewSolutions(string requestId);
        Task<string> GiveFeedback(string requestId, string feedbackDetails);
        Task<string> RespondToSolution(string requestId, string responseDetails);
    }
}
