using System.Runtime.Serialization;

namespace UserLoginTraining1705.Exceptions
{
    [Serializable]
    internal class NotActiveException : Exception
    {
        public NotActiveException()
        {
        }

        public NotActiveException(string? message) : base(message)
        {
        }

        public NotActiveException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NotActiveException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}