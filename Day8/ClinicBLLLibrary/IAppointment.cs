using ClinicModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicBLLLibrary
{
    public interface IAppointmentService
    {
        void AddAppointment(Appointment appointment);
        void UpdateAppointment(Appointment appointment);
        void DeleteAppointment(int id);
        Appointment GetAppointmentById(int id);
        
    }
}
