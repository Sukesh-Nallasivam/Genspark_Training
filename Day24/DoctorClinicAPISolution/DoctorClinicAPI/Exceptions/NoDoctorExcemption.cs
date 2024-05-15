using System.Runtime.Serialization;

namespace DoctorClinicAPI.Exceptions
{
    [Serializable]
    internal class NoDoctorExcemption : Exception
    {
        public NoDoctorExcemption()
        {
        }

        public NoDoctorExcemption(string? message) : base(message)
        {
        }

        public NoDoctorExcemption(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NoDoctorExcemption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
        public override string ToString()
        {
            return "Warning: No doctor is available in the clinic.";
        }
    }
}