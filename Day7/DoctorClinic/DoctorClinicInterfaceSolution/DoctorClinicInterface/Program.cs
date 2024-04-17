using ClinicModelLibrary;

namespace DoctorClinicInterface
{
    internal class Program
    {        
        void ChooseOperation()
        {
            Console.WriteLine("Choose task");
            int Task = 1;
            if(Task == 1)
            {
                IDoctor data = new Doctor();
            }
            else if(Task == 2)
            {
                IPatient data = new Patient();
            }
            else if( Task == 3)
            {
                IAppointment data = new Appointment();
            }
            
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.ChooseOperation();
        }
    }
}
