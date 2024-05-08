using System;
using System.Collections.Generic;

namespace ClinicDALLibrary.Models
{
    public partial class MedicalHistory
    {
        public int? PatientId { get; set; }
        public string? MedicalCondition { get; set; }

        public virtual Patient? Patient { get; set; }
    }
}
