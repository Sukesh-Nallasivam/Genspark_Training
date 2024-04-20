namespace DoctorDetails
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Doctor details");
            Doctor first = new Doctor();

            Console.WriteLine("Enter ID of doctor");
            first.DoctorId=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter name of the doctor");
            first.Name = Console.ReadLine();
            Console.WriteLine("Enter age of doctor");
            first.Age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter experience of doctor");
            first.Experience = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter speciality of doctor");
            first.Speciality = Console.ReadLine();
            Console.WriteLine("Enter qualification of doctor");
            first.Qualification = Console.ReadLine();
            first.PrintDoctorDetails();
            
        }
    }
}
