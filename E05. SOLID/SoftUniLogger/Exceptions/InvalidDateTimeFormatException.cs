namespace SoftUniLogger.Exceptions
{
    using System;

    public class InvalidDateTimeFormatException : Exception
    {
        private const string DefaultMessage = "Provided DateTime was not in correct format!";

        public InvalidDateTimeFormatException()
            : base(DefaultMessage)
        {
            
        }
    }
}
