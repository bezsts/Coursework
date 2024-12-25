using System.Runtime.Serialization;

namespace WPF.Common.Exceptions
{
    internal class ScenarioMissingProperty : Exception
    {
        public ScenarioMissingProperty()
        {
        }

        public ScenarioMissingProperty(string? message) : base(message)
        {
        }

        public ScenarioMissingProperty(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected ScenarioMissingProperty(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
