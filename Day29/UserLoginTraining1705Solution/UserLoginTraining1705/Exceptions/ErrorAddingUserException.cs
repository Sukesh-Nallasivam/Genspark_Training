using System.Runtime.Serialization;

namespace UserLoginTraining1705.Exceptions
{
    [Serializable]
    internal class ErrorAddingUserException : Exception
    {
        public ErrorAddingUserException()
        {
        }

        public ErrorAddingUserException(string? message) : base(message)
        {
        }

        public ErrorAddingUserException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ErrorAddingUserException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}