using System;
using System.Collections.Generic;

namespace ClinicDALLibrary.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int DoctorId { get; set; }
        public string? DoctorName { get; set; }
        public string? Speciality { get; set; }
        public string? Contact { get; set; }
        public string? ConsultingHours { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
