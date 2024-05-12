using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using RequestTrackerBLLAdmin;
using RequestTrackerModelLibrary;
using System.ComponentModel.Design;

namespace RequestTrackerFEAPP
{
    public class AdminConsole:AdminOperation
    {
        private readonly AdminOperation _adminOperations;

        public AdminConsole(Employee employee)
        {
            _adminOperations = new AdminOperation();
            Console.WriteLine($"Welcome Admin {employee.Name}");

            Console.WriteLine("Select operation:");

            Console.WriteLine("1. Raise Request");
            Console.WriteLine("2. View Request Status (All Requests)");
            Console.WriteLine("3. View Solutions (All Solutions)");
            Console.WriteLine("4. Give Feedback (Only for request raised by them)");
            Console.WriteLine("5. Respond to Solution (Only for request raised by them)");
            Console.WriteLine("6. Provide Solution");
            Console.WriteLine("7. ak Request as Closed");
            Console.WriteLine("8. View Feedbacks (Only feedbacks given to them)");

            Console.Write("Enter your choice: ");
            int userInput = Convert.ToInt32(Console.ReadLine());

            switch (userInput)
            {
                case 0:
                    Console.WriteLine("ThankYou");
                    break;
                case 1:
                    Console.WriteLine("Enter your request");
                    string RequestInput = Console.ReadLine() ?? String.Empty;   
                    _adminOperations.RaiseRequest(employee,RequestInput);
                    break;
                case 2:
                    _adminOperations.ViewAllRequests();
                    break;
                case 3:
                    _adminOperations.ViewAllSolutions();
                    break;
                case 4:
                    _adminOperations.GiveFeedback();
                    break;
                case 5:
                    _adminOperations.RespondToSolution();
                    break;
                case 6:
                    Console.WriteLine("Enter request Id");
                    int Selection = SelectRequest();
                    _adminOperations.ProvideSolution();
                    break;
                case 7:
                    _adminOperations.MarkRequestAsClosed();
                    break;
                case 8:
                    _adminOperations.ViewFeedbacks();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
        public int SelectRequest()
        {
            Request DisplayRequests = new Request();
            IDictionary<int,String> RequestList = new Dictionary<int,String>();
            foreach requestListeach in RequestList.Values)
            {

            }
            return Selection;
        }
    }
}
