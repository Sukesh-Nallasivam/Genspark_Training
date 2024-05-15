using System;

namespace DoctorClinicAPI.Exceptions
{
    [Serializable]
    public class MissingSpecialtyException : Exception
    {
        // Error code property
        public int ErrorCode { get; }

        // Default constructor
        public MissingSpecialtyException(int errorCode)
        {
            ErrorCode = errorCode;
        }
        // Constructor with message and error code

        // Constructor with message indicating specialty not found and error code
        public MissingSpecialtyException(string specialty, int errorCode) : base($"Specialty '{specialty}' not found.")
        {
            ErrorCode = errorCode;
        }

        // Constructor with message, inner exception, and error code
        public MissingSpecialtyException(string message, Exception innerException, int errorCode) : base(message, innerException)
        {
            ErrorCode = errorCode;
        }

        // Constructor for serialization
        protected MissingSpecialtyException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context, int errorCode) : base(info, context)
        {
            ErrorCode = errorCode;
        }
    }
}
