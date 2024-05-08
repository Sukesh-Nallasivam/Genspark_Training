using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicModelLibrary
{
    public class Appointment : IAppointment
    {
        [Key]
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public string Name { get; set; }
        public double PatientContact { get; set; }
        public string DctorId { get; set; }
        public DateTime AppointmentDateTime { get; set; }
        public string Purpose { get; set; }
        public string AppointmentStatus {  get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="appointmentId"></param>
        /// <param name="patientId"></param>
        /// <param name="name"></param>
        /// <param name="patientContact"></param>
        /// <param name="dctorId"></param>
        /// <param name="appointmentDateTime"></param>
        /// <param name="purpose"></param>
        /// <param name="appointmentStatus"></param>
        public Appointment(int appointmentId, int patientId, string name, double patientContact, string dctorId, DateTime appointmentDateTime, string purpose, string appointmentStatus)
        {
            AppointmentId = appointmentId;
            PatientId = patientId;
            Name = name;
            PatientContact = patientContact;
            DctorId = dctorId;
            AppointmentDateTime = appointmentDateTime;
            Purpose = purpose;
            AppointmentStatus = appointmentStatus;
        }

        public Appointment()
        {
        }

        //public void AddAppointment(Appointment appointment)
        //{

        //}


    }
}
