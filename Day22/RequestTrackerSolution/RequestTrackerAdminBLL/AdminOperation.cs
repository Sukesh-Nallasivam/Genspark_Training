using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;

namespace RequestTrackerBLLAdmin
{
    public class AdminOperation : IAdminOperation
    {
        private readonly EmployeeRequestRepository _employeeRequestRepository;
        private readonly RequestSolutionRepository _requestSolutionRepository;
        public Task<SolutionFeedback> GiveFeedback(string requestId, string feedbackDetails)
        {
            throw new NotImplementedException();
        }

        public Task<bool> MarkRequestAsClosed(string requestId)
        {
            throw new NotImplementedException();
        }

        public Task<RequestSolution> ProvideSolution(int requestId, string solutionDetails,Employee employee)
        {
            RequestSolution NewRequestSolution = new RequestSolution
            {
                RequestId = requestId,
                SolutionDescription = solutionDetails,
                SolvedBy = employee.Id
            };
            return _requestSolutionRepository.AddSolution(NewRequestSolution);
        }

        public Task<Request> RaiseRequest(Employee employee,String RequestInput)
        {
            Request newRequest = new Request
            {

                RequestMessage = RequestInput,
                RequestDate = DateTime.Now,
                RequestStatus = "Open",
                RequestRaisedBy = employee.Id                         

            };
            return _employeeRequestRepository.AddRequest(newRequest);

        }

        public Task<SolutionFeedback> RespondToSolution(string requestId, string responseDetails)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Request>> ViewAllRequests()
        {
            return await _employeeRequestRepository.GetAllRequests();

        }

        public Task<IEnumerable<RequestSolution>> ViewAllSolutions()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SolutionFeedback>> ViewFeedbacks()
        {
            throw new NotImplementedException();
        }
    }
}
