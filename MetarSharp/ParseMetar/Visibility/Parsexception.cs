using System.Runtime.Serialization;

namespace MetarSharp.Parse
{
    [Serializable]
    internal class Parsexception : Exception
    {
        public Parsexception()
        {
        }

        public Parsexception(string? message) : base(message)
        {
        }

        public Parsexception(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected Parsexception(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}