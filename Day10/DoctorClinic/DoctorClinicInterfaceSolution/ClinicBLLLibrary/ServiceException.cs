using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClinicBLLLibrary
{
    
    public class PatientServiceException : Exception
    {
        public PatientServiceException() : base() { }
        public PatientServiceException(string message) : base(message) { }
        public PatientServiceException(string message, Exception innerException) : base(message, innerException) { }
    }
    public class DoctorServiceException : Exception
    {
        public DoctorServiceException() : base() { }
        public DoctorServiceException(string message) : base(message) { }
        public DoctorServiceException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class AppointmentServiceException : Exception
    {
        public AppointmentServiceException() : base() { }
        public AppointmentServiceException(string message) : base(message) { }
        public AppointmentServiceException(string message, Exception innerException) : base(message, innerException) { }
    }
}
