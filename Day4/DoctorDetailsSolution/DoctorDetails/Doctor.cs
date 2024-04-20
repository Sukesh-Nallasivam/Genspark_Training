using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorDetails
{
    class Doctor
    {
        public int DoctorId {  get; set; }
        public string Name {  get; set; }
        public int Age { get; set; }
        public int Experience { get; set; }
        public string Qualification {  get; set; }
        public string Speciality {  get; set; }
        public Doctor() {
            DoctorId = 0;
            Name=string.Empty;
            Age = 0;
            Experience = 0;
            Qualification = string.Empty;
            Speciality = string.Empty;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="doctorId">"Enter doctor ID as Integer"</param>
        /// <param name="name">Enter doctor name in string</param>
        /// <param name="age">Enter doctor age as Integer</param>
        /// <param name="experience">Enter doctor experience as Integer</param>
        /// <param name="qualification">Enter doctor qualification as Integer</param>
        /// <param name="speciality">Enter doctor speciality as Integer</param>
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
            Console.WriteLine($"Doctor ID\t:\t{DoctorId}");
            Console.WriteLine($"Doctor Name\t:\t{Name}");
            Console.WriteLine($"Doctor Age\t:\t{Age}");
            Console.WriteLine($"Doctor Name\t:\t{Experience}");
            Console.WriteLine($"Doctor ID\t:\t{Qualification}");
            Console.WriteLine($"Doctor Name\t:\t{Speciality}");
        }
    }
}
