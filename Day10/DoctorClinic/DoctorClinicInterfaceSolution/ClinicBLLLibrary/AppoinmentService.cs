using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicDALLibrary;
using ClinicModelLibrary;

namespace ClinicBLLLibrary
{
    public class AppointmentService : IAppointmentService
    {
        private readonly AppointmentRepositoryClass _appointmentRepository;

        public AppointmentService(AppointmentRepositoryClass appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;

        }

        public void AddAppointment(Appointment appointment)
        {
            
            try
            {
                _appointmentRepository.Add(appointment);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding appointment {ex.Message}");
            }
        }

        public void UpdateAppointment(Appointment appointment)
        {
            //_appointmentRepository.Update(appointment);
            try
            {
                _appointmentRepository.Update(appointment);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating appointment ");
            }
        }

        public void DeleteAppointment(int id)
        {
            try
            {
                _appointmentRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting appointment ");
            }
        }

        public Appointment GetAppointmentById(int id)
        {
            return _appointmentRepository.Get(id);
        }
        
    }
}

