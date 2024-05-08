using System;
using System.Collections.Generic;

namespace ClinicDALLibrary.Models
{
    public partial class PreviousConsultation
    {
        public int? PatientId { get; set; }
        public int? ConsultantId { get; set; }

        public virtual Doctor? Consultant { get; set; }
        public virtual Patient? Patient { get; set; }
    }
}
