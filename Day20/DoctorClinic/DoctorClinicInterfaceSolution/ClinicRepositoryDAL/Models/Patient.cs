using System;
using System.Collections.Generic;

namespace ClinicDALLibrary.Models
{
    public partial class Patient
    {
        public Patient()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int PatientId { get; set; }
        public string? PatientName { get; set; }
        public int? PatientAge { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
