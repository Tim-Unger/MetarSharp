namespace MetarSharp.Exceptions
{
    [Serializable]
    public class ReadMetarException : Exception
    {
        public ReadMetarException()
        {
        }

        public ReadMetarException(string message) : base(message)
        {
        }

        public ReadMetarException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}