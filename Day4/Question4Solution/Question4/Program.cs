using DoctorDetails;
using System;

namespace Question4
{
    class Program
    {
        static Doctor[] DataCollection(int count)
        {
            Doctor[] doctors = new Doctor[count];
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Enter details for Doctor {i + 1}:");
                Console.WriteLine("Enter Doctor ID:");
                int doctorId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Doctor Name:");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Doctor Age:");
                int age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Doctor Experience (in years):");
                int experience = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Doctor Qualification:");
                string qualification = Console.ReadLine();
                Console.WriteLine("Enter Doctor Speciality:");
                string speciality = Console.ReadLine();

                doctors[i] = new Doctor(doctorId, name, age, experience, qualification, speciality);
            }
            return doctors;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of doctors:");
            int numberOfDoctors = int.Parse(Console.ReadLine());

            Doctor[] dataEntry = DataCollection(numberOfDoctors);
            Console.WriteLine("************************");
            Console.WriteLine();
            Console.WriteLine("Enter speciality to filter doctor(s):");
            string speciality = Console.ReadLine();
            int filter = 0;
            // Print details of each doctor
            foreach (var doctor in dataEntry)
            {
                //removing case sensitive
                if (doctor.Speciality.ToLower() == speciality.ToLower())
                {
                    doctor.PrintDoctorDetails();
                    filter = 1;
                }
                
                
            }
            if (filter == 0)
            {
                Console.WriteLine("No Docters found...");
            }
        }
    }
}
