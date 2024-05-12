using Microsoft.EntityFrameworkCore;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary
{
    public class EmployeeRequestRepository : EmployeeRepository
    {
        public EmployeeRequestRepository(RequestTrackerContext context) : base(context)
        {
        }
        public  async override Task<IList<Employee>> GetAll()
        {
            return await _context.Employees.Include(e => e.RequestsRaised).ToListAsync();
        }
        public async override Task<Employee> Get(int key)
        {
            var employee = _context.Employees.Include(e => e.RequestsRaised).SingleOrDefault(e => e.Id == key);
            return employee;
        }
        public async Task<Request> AddRequest(Request newRequest)
        {
            _context.Requests.Add(newRequest);
            await _context.SaveChangesAsync();
            return newRequest;
        }
        public async Task<Request> UpdateStatus(int RequestId, string Status)
        {
            var request = await _context.Requests.FindAsync(RequestId);
            if (request != null)
            {
                request.RequestStatus = Status;
                await _context.SaveChangesAsync();
            }
            return request;
        }

    }
}
