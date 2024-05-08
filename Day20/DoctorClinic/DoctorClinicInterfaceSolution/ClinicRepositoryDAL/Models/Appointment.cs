using System;
using System.Collections.Generic;

namespace ClinicDALLibrary.Models
{
    public partial class Appointment
    {
        public int AppointmentId { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public DateTime? AppointmentDateTime { get; set; }
        public string? Purpose { get; set; }
        public string? AppointmentStatus { get; set; }

        public virtual Doctor? Doctor { get; set; }
        public virtual Patient? Patient { get; set; }
    }
}
