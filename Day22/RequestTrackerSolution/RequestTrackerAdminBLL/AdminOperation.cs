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

        public AdminOperation()
        {
        }

        public AdminOperation(EmployeeRequestRepository employeeRequestRepository, RequestSolutionRepository requestSolutionRepository)
        {
            _employeeRequestRepository = employeeRequestRepository ?? throw new ArgumentNullException(nameof(employeeRequestRepository));
            _requestSolutionRepository = requestSolutionRepository ?? throw new ArgumentNullException(nameof(requestSolutionRepository));
        }

        public Task<SolutionFeedback> GiveFeedback(int RequestId, string feedbackDetails)
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
                RequestStatus = "Open",
                RequestRaisedBy = employee.Id                         

            };
            return _employeeRequestRepository.AddRequest(newRequest);

        }

        public async Task<SolutionFeedback> RespondToSolution(int solutionId, string responseDetails)
        {
            var solution = await _requestSolutionRepository.GetSolutionById(solutionId);

            if (solution == null)
            {
                throw new ArgumentException("Solution with the provided ID not found.", nameof(solutionId));
            }

            solution.SolutionDescription = responseDetails;

            await _requestSolutionRepository.UpdateSolution(solution);

            return new SolutionFeedback
            {
                SolutionId = solution.SolutionId,
                Remarks = responseDetails,
                FeedbackDate = DateTime.Now
            };
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
