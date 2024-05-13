using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;

namespace RequestTrackerBLLUser
{
    public class UserOperation : IUserOperation
    {
        private readonly EmployeeRequestRepository _employeeRequestRepository;
        private readonly RequestSolutionRepository _requestSolutionRepository;
        public Task<string> GiveFeedback(string requestId, string feedbackDetails)
        {
            throw new NotImplementedException();
        }

        public Task<Request> RaiseRequest(Employee employee, String RequestInput)
        {
            Request newRequest = new Request
            {
                RequestMessage = RequestInput,
                RequestDate = DateTime.Now,
                RequestStatus = "Open",
                RequestRaisedBy = employee.Id,
            };
            return _employeeRequestRepository.AddRequest(newRequest);

        }
        public Task<string> RespondToSolution(string requestId, string responseDetails)
        {
            throw new NotImplementedException();
        }

        public async void ViewRequestStatus(int userId)
        {
            var requestsTask = _employeeRequestRepository.GetRequestsByEmployeeId(userId);
            var requests = await requestsTask;

            Console.WriteLine("Requests:");
            foreach (var request in requests)
            {
                Console.WriteLine($"Request ID: {request.RequestNumber},Request: {request.RequestMessage}, Status: {request.RequestStatus}");
                if(request.RequestSolutions != null)
                {
                    Console.WriteLine($"Solution : {request.RequestSolutions}");
                }
            }
        }


        public Task<IList<SolutionFeedback>> ViewSolutions(string requestId)
        {
            throw new NotImplementedException();
        }
    }
}
