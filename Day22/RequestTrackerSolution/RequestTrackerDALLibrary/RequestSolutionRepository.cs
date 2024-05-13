using Microsoft.EntityFrameworkCore;
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
        public async Task<RequestSolution> GetSolutionByRequestId(int requestId)
        {
            return await _context.RequestSolutions
                .FirstOrDefaultAsync(rs => rs.RequestId == requestId);
        }
        public async Task<RequestSolution> GetSolutionById(int solutionId)
        {
            return await _context.RequestSolutions.FindAsync(solutionId);
        }

        public async Task<RequestSolution> UpdateSolution(RequestSolution updatedSolution)
        {
            var existingSolution = await _context.RequestSolutions.FindAsync(updatedSolution.SolutionId);

            if (existingSolution == null)
            {
                throw new ArgumentException("Solution with the provided ID not found.", nameof(updatedSolution.SolutionId));
            }

            // Update existing solution properties
            existingSolution.SolutionDescription = updatedSolution.SolutionDescription;
            existingSolution.SolvedBy = updatedSolution.SolvedBy;
            existingSolution.ResponseDetails = updatedSolution.ResponseDetails;

            // Save changes to the database
            await _context.SaveChangesAsync();

            return existingSolution;
        }
    }
}
