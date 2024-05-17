using System.Runtime.Serialization;

namespace PizzaStore.Services
{
    [Serializable]
    internal class EmptyDataBaseException : Exception
    {
        public EmptyDataBaseException()
        {
        }

        public EmptyDataBaseException(string? message) : base(message)
        {
        }

        public EmptyDataBaseException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected EmptyDataBaseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}