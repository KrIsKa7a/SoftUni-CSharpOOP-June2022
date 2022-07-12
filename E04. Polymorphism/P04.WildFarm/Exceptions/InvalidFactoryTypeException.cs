namespace P04.WildFarm.Exceptions
{
    using System;

    public class InvalidFactoryTypeException : Exception
    {
        private const string DefaultMessage = "Invalid type!";

        public InvalidFactoryTypeException()
            : base(DefaultMessage)
        {
            
        }

        public InvalidFactoryTypeException(string message)
            : base(message)
        {
            
        }
    }
}
