using System.Numerics;

namespace DoctorDetails
{
    internal class Program
    {
        Doctor DataCollection(int id)
        {
            Doctor first = new Doctor();
            Console.WriteLine("Enter ID of doctor");
            first.DoctorId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Enter name of the doctor ID {first.DoctorId}");
            first.Name = Console.ReadLine();
            Console.WriteLine("Enter age of doctor");
            first.Age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter experience of doctor");
            first.Experience = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter speciality of doctor");
            first.Speciality = Console.ReadLine();
            Console.WriteLine("Enter qualification of doctor");
            first.Qualification = Console.ReadLine();
            return first;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter no of doctors need to be added");
            int count = Convert.ToInt32(Console.ReadLine());
            Program program = new Program();
            Doctor[] data = new Doctor[count];
            for (int i = 1; i <= data.Length; i++)
            {
                data[i-1] = program.DataCollection(i);
            }
            for (int i = 1; i <= data.Length; i++)
            {
                data[i-1].PrintDoctorDetails();
            }

        }
    }
}
