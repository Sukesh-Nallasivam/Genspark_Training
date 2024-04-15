namespace ReferenceForEmployeeTracker
{
    public class Employee
    {
        int age;
        DateTime dob;
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age
        {
            get
            {
                return age;
            }
        }
        public DateTime DOB
        {
            get => dob;
            set
            {
                dob = value;
                age = ((DateTime.Today - DOB).Days) / 365;
            }
        }
        public double Salary
        {
            get; set;
        }
        public Employee()
        {
            Id = 0;
            Name=string.Empty;
            Salary = 0.0;
            DOB = new DateTime();

        }
        public Employee(int id,string name,DateTime dob,double salary)
        {
            Id = id;
            Name = name;
            Salary = salary;
            DOB = dob;
        }
        public void BuildEmployeeFromConsole()
        {
            Console.WriteLine("Enter the Employee Name");
            Name=Console.ReadLine()?? String.Empty;
            Console.WriteLine("Enter Date of Birth of Employee");
            DOB=Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter Base Salary of Employee");
            Salary=Convert.ToDouble(Console.ReadLine());
        }
        public void PrintAllEmployeeDetails()
        {
            Console.WriteLine("Employee ID          \t:\t" + Id);
            Console.WriteLine("Employee Name        \t:\t" + Name);
            Console.WriteLine("Date of Birth        \t:\t" + DOB);
            Console.WriteLine("Age of Employee      \t:\t" + Age);
            Console.WriteLine("Salary of Employee   \t:\t" + Salary);
        }
    }
}
