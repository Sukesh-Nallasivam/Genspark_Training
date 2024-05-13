using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;

namespace RequestTrackerBLLUser
{
    public class UserOperation : IUserOperation
    {
        private readonly EmployeeRequestRepository _employeeRequestRepository;
        private readonly RequestSolutionRepository _requestSolutionRepository;

        public UserOperation()
        {
        }

        public UserOperation(EmployeeRequestRepository employeeRequestRepository, RequestSolutionRepository requestSolutionRepository)
        {
            _employeeRequestRepository = employeeRequestRepository;
            _requestSolutionRepository = requestSolutionRepository;
        }
        public Task<string> GiveFeedback(string requestId, string feedbackDetails)
        {
            throw new NotImplementedException();
        }

        public async Task<Request> RaiseRequest(Employee employee, String RequestInput)
        {
            Request newRequest = new Request
            {
                RequestNumber = 1,
                RequestMessage = RequestInput,
                RequestDate = DateTime.Now,
                RequestStatus = "Open",
                RequestRaisedBy = employee.Id,
            };
            return await _employeeRequestRepository.AddRequest(newRequest);

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
                if (request.RequestSolutions != null)
                {
                    Console.WriteLine($"Solution : {request.RequestSolutions}");
                }
            }
        }


        public async Task<IList<RequestSolution>> ViewSolutions(int userId)
        {
            var requests = await _employeeRequestRepository.GetRequestsByEmployeeId(userId);
            var solutions = new List<RequestSolution>();

            foreach (var request in requests)
            {
                var solution = await _requestSolutionRepository.GetSolutionByRequestId(request.RequestNumber);
                if (solution != null)
                {
                    solutions.Add(new RequestSolution
                    {
                        RequestId = request.RequestNumber,
                        SolvedByEmployee = solution.SolvedByEmployee,
                        SolutionDescription = solution.SolutionDescription
                    });
                    solutions.Add(solution);
                }
            }

            return solutions;
        }

    }
}
