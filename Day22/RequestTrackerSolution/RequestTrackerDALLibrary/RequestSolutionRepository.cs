using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    public class RequestSolutionRepository
    {

        private readonly RequestTrackerContext _context;
        private readonly EmployeeRepository _employeeRepository;
        private readonly EmployeeRequestRepository _employeeRequestRepository;

        public RequestSolutionRepository(RequestTrackerContext context, EmployeeRepository employeeRepository, EmployeeRequestRepository employeeRequestRepository)
        {
            _context = context;
            _employeeRepository = employeeRepository;
            _employeeRequestRepository = employeeRequestRepository;
        }

        public async Task<RequestSolution> AddSolution(RequestSolution NewRequestSolution)
        {
            _context.RequestSolutions.Add(NewRequestSolution);
            await _context.SaveChangesAsync();
            await _employeeRequestRepository.UpdateStatus(NewRequestSolution.RequestId, "Solution(s) Added");
            return NewRequestSolution;
        }
    }
}
