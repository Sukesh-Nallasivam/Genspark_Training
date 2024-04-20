using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorDetails
{
    class Doctor
    {

        public int DoctorId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Experience { get; set; }
        public string Qualification { get; set; }
        public string Speciality { get; set; }
        public Doctor()
        {
            DoctorId = 0;
            Name = string.Empty;
            Age = 0;
            Experience = 0;
            Qualification = string.Empty;
            Speciality = string.Empty;
        }
        public Doctor(int doctorId, string name, int age, int experience, string qualification, string speciality)
        {
            DoctorId = doctorId;
            Name = name;
            Age = age;
            Experience = experience;
            Qualification = qualification;
            Speciality = speciality;
        }
        public void PrintDoctorDetails()
        {
            Console.WriteLine($"Details of filtered doctor(s) {Name}");
            Console.WriteLine($"Doctor ID\t:\t{DoctorId}");
            //Console.WriteLine($"Doctor Name\t:\t{Name}");
            Console.WriteLine($"Doctor Age\t:\t{Age}");
            Console.WriteLine($"Doctor Name\t:\t{Experience}");
            Console.WriteLine($"Doctor ID\t:\t{Qualification}");
            Console.WriteLine($"Doctor Name\t:\t{Speciality}");
            Console.WriteLine();
        }
    }
}
