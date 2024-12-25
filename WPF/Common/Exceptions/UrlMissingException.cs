using System.Runtime.Serialization;

namespace WPF.Common.Exceptions
{
    public class UrlMissingException : Exception
    {
        public UrlMissingException()
        {
        }

        public UrlMissingException(string? message) : base(message)
        {
        }

        public UrlMissingException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected UrlMissingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
