using ReferenceForEmployeeTracker;

namespace EmployeeTracker
{
    internal class Program
    {
        Employee[] employees;
        public Program()
        {
            employees = new Employee[3];
        }

        public void ListTask()
        {
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. PrintAllEmployees");
            Console.WriteLine("3. UpdateEmployee");
            Console.WriteLine("4. DeleteEmployee");
            Console.WriteLine("5. SearchEmployee");
            Console.WriteLine("0. Exit from Main Menu");
        }
        void TaskSelection()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("Choose the option to perform operation");
                ListTask();
                choice=Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 0:
                        Console.WriteLine("Thank you");
                        break;
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        PrintAllEmployees();
                        break;
                    case 3:
                        UpdateEmployee();
                        break;
                    case 4:
                        DeleteEmployee();
                        break;
                    case 5:
                        SearchEmployee();
                        break;
                    default: Console.WriteLine("Enter Correct choice");
                        break;
                }
            }while(choice!=0);
        }

        void AddEmployee()
        {
            for(int i = 0;i< employees.Length; i++)
            {
                if (employees[i] == null)
                {
                    employees[i] = CreateEmployee(i);
                }
            }
        }
        Employee CreateEmployee(int id)
        {
            Employee employee = new Employee();
            employee.Id=100+id;
            employee.BuildEmployeeFromConsole();
            return employee;
        }
        void PrintAllEmployees()
        {
            for(int i = 0;i< employees.Length; i++)
            {
                if (employees[i] != null)
                {
                    PrintEmployee(employees[i]);
                }
            }
        }
        void PrintEmployee(Employee employee)
        {
            Console.WriteLine("---------------");
            employee.PrintAllEmployeeDetails();
            Console.WriteLine("---------------");
        }
        void SearchEmployee()
        {
            int WayToFind;
            do
            {
                Console.WriteLine("1. Find by ID ");
                Console.WriteLine("2. Find by name ");
                Console.WriteLine("3. Just list all");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Choose an option:");
                WayToFind = Convert.ToInt32(Console.ReadLine());
                switch (WayToFind)
                {
                    case 0:
                        Console.WriteLine("Exiting...");
                        break;
                    case 1:
                        Employee employeeById = SearchEmployeeById();
                        if (employeeById == null)
                            Console.WriteLine("No such Employee is present");
                        else
                            PrintEmployee(employeeById);
                        break;
                    case 2:
                        Employee employeeByName = SearchEmployeeByName();
                        if (employeeByName == null)
                            Console.WriteLine("No such Employee is present");
                        else
                            PrintEmployee(employeeByName);
                        break;
                    case 3:
                        PrintAllEmployees();
                        break;
                    default:
                        Console.WriteLine("Choose correct option");
                        break;
                }
            } while (WayToFind != 0);
        }

        Employee SearchEmployeeById()
        {
            Console.WriteLine("Enter ID to find ");
            int id = Convert.ToInt32(Console.ReadLine());
            Employee employee = null;
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] != null && employees[i].Id == id)
                {
                    employee = employees[i];
                    break;
                }
            }
            return employee;
        }

        Employee SearchEmployeeByName()
        {
            Console.WriteLine("Enter name to find");
            string name = (Console.ReadLine()??String.Empty).ToLower();
            Employee employee = null;
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] != null && (employees[i].Name).ToLower() == name)
                {
                    employee = employees[i];
                    break;
                }
            }
            return employee;
        }
        void UpdateEmployee()
        {
            Employee employee = SearchEmployeeById();
            if (employee == null)
            {
                Console.WriteLine("No such Employee is present");
                return;
            }

            Console.WriteLine("Enter updated details for the employee:");
            employee.BuildEmployeeFromConsole();
            Console.WriteLine("Employee data updated successfully:");
            PrintEmployee(employee);
        }
        void DeleteEmployee()
        {
            Employee employee = SearchEmployeeById();
            if (employee == null)
            {
                Console.WriteLine("No such Employee is present");
                return;
            }


            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] != null && employees[i].Id == employee.Id)
                {
                    employees[i] = null;
                    Console.WriteLine("Employee data deleted successfully.");
                    return;
                }
            }
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.TaskSelection();
            
        }
    }
}
