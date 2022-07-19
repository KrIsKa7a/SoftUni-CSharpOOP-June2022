namespace SoftUniLogger.Messages
{
    using System;

    using Enums;
    using Exceptions;
    using Interfaces;
    using Validators;
    using Validators.Interfaces;

    public class Message : IMessage
    {
        private const string EmptyArgumentMessage = "Argument cannot be null or empty string!";

        private string logTime;
        private string messageText;
        
        private readonly IValidator dateTimeValidator;

        public Message()
        {
            this.dateTimeValidator = new DateTimeValidator();
        }

        public Message(string logTime, string messageText, ReportLevel level)
            : this()
        {
            this.LogTime = logTime;
            this.MessageText = messageText;
            this.Level = level;
        }

        public string LogTime
        {
            get
            {
                return this.logTime;
            }
            private set
            {
                if (!this.dateTimeValidator.IsValid(value))
                {
                    throw new InvalidDateTimeFormatException();
                }
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(this.LogTime), EmptyArgumentMessage);
                }

                this.logTime = value;
            }
        }

        public string MessageText
        {
            get
            {
                return this.messageText;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(this.MessageText), EmptyArgumentMessage);
                }

                this.messageText = value;
            }
        }

        public ReportLevel Level { get; }
    }
}
