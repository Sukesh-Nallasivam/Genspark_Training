using RequestTrackerBLLibrary;
using RequestTrackerModelLibrary;
using System.Threading.Channels;

namespace RequestTrackerFEAPP
{
    internal class Program
    {
        private bool result;

        async Task EmployeeLoginAsync(int username, string password)
        {
            Employee employee = new Employee() { Password = password,Id=username };
            IEmployeeLoginBL employeeLoginBL = new EmployeeLoginBL();
            Console.WriteLine("Are you Admin? If yes press 'Y' or 'y', else press any other key");
            string userInput = Console.ReadLine() ?? "";
            bool isUserAdmin = userInput.Equals("Y", StringComparison.OrdinalIgnoreCase);
            if (isUserAdmin)
            {
                result = await employeeLoginBL.AdminLogin(employee);
                if (result)
                {
                    await Console.Out.WriteLineAsync("Login Success");
                    AdminConsole AdminInstance = new AdminConsole(employee);
                }
                else
                {
                    Console.Out.WriteLine("Invalid username or password");
                }
            }
            else {
                result = await employeeLoginBL.Login(employee);
                if (result)
                {
                    await Console.Out.WriteLineAsync("Login Success");
                    UserConsole UserInstance = new UserConsole(employee);
                }
                else
                {
                    Console.Out.WriteLine("Invalid username or password");
                }
            }
            

        }
        async Task GetLoginDeatils()
        {
            await Console.Out.WriteLineAsync("Please enter Employee Id");
            int id = Convert.ToInt32(Console.ReadLine());
            await Console.Out.WriteLineAsync("Please enter your password");
            string password = Console.ReadLine() ?? "";
            await EmployeeLoginAsync(id,password);
        }
        static async Task Main(string[] args)
        {
            await new Program().GetLoginDeatils();
        }
    }
}
