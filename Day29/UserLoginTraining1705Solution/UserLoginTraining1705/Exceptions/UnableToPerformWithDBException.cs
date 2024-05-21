using System.Runtime.Serialization;

namespace UserLoginTraining1705.Exceptions
{
    [Serializable]
    internal class UnableToPerformWithDBException : Exception
    {
        public UnableToPerformWithDBException()
        {
        }

        public UnableToPerformWithDBException(string? message) : base(message)
        {
        }

        public UnableToPerformWithDBException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UnableToPerformWithDBException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}