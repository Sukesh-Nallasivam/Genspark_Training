using System;
using ClinicBLLLibrary;
using ClinicDALLibrary;
using ClinicModelLibrary;

namespace DoctorClinicInterface
{
    internal class Program
    {
        void ChooseOperation()
        {
            Console.WriteLine("Choose task");
            int Task = 1;
            if (Task == 1)
            {
                IDoctorService doctorService = new DoctorService(new DoctorRepositoryClass());
                
            }
            else if (Task == 2)
            {
                IPatientService patientService = new PatientService(new PatientRepositoryClass());
                
            }
            else if (Task == 3)
            {
                IAppointmentService appointmentService = new AppointmentService(new AppointmentRepositoryClass());
                
            }

        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.ChooseOperation();
        }
    }
}
