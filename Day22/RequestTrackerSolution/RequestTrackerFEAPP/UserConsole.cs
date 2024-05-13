using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RequestTrackerBLLUser;
using RequestTrackerModelLibrary;

namespace RequestTrackerFEAPP
{
    internal class UserConsole
    {
        private readonly UserOperation _userOperations;

        public UserConsole(Employee employee)
        {
            _userOperations = new UserOperation();
            bool continueLoop = true;
            while (continueLoop)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Raise Request");
                Console.WriteLine("2. View Request Status");
                Console.WriteLine("3. View Solutions");
                Console.WriteLine("4. Give Feedback");
                Console.WriteLine("5. Respond to Solution");
                Console.WriteLine("6. Exit");

                Console.Write("Enter your choice: ");
                int userInput = Convert.ToInt32(Console.ReadLine());

                switch (userInput)
                {
                    case 1:
                        Console.WriteLine("Enter your request");
                        string RequestInput = Console.ReadLine() ?? String.Empty;
                        _userOperations.RaiseRequest(employee, RequestInput);
                        break;
                    case 2:
                        _userOperations.ViewRequestStatus(employee.Id);
                        break;
                    case 3:
                        
                        _userOperations.ViewSolutions();
                        break;
                    case 4:
                        _userOperations.GiveFeedback();
                        break;
                    case 5:
                        _userOperations.RespondToSolution();
                        break;
                    case 6:
                        continueLoop = false;
                        Console.WriteLine("Logged Out");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}
