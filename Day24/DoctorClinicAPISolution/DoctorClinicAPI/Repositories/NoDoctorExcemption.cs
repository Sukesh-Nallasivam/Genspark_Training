using System.Runtime.Serialization;

namespace DoctorClinicAPI.Repositories
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
    }
}