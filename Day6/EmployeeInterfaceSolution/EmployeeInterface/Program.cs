using ReferenceClassesForEmployees;

namespace EmployeeInterface
{
    internal class Program
    {
        GovernmentRules Data;
        void PrintDetails()
        {
            Data.CompanyDetail();
            Data.EmployeeDetail();
            Console.WriteLine($"PF paid By the Employee:\t{Data.EmployeePF(25000.00)}");
            Console.WriteLine(Data.LeaveDetails());
            Console.WriteLine(Data.GratuityAmount(5,25000) != null ? Data.GratuityAmount(5, 25000).ToString() : "Not Applicable");

        }
        void ChooseCompany()
        {
            Console.WriteLine("Enter Comapany Name ");
            string Company = (Console.ReadLine()??String.Empty).ToLower();
            if (Company == "CTS".ToLower())
            {
                //employee = new Employee();
                Data = new CTS(101,"Mr.A","DEV1");
                
            }
            else if(Company =="Accenture".ToLower())
            {
                //employee = new Employee();
                Data = new Accenture(123, "Mr.B", "DEV2");
            }
            

        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.ChooseCompany();
            program.PrintDetails();
        }
    }
}
