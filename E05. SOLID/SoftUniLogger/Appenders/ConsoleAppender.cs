namespace SoftUniLogger.Appenders
{
    using System;
    using Enums;
    using Formatters;
    using Formatters.Interfaces;
    using Interfaces;
    using Layouts.Interfaces;
    using Messages.Interfaces;

    public class ConsoleAppender : IAppender
    {
        private readonly IFormatter formatter;

        private ConsoleAppender()
        {
            this.Count = 0;
        }

        public ConsoleAppender(ILayout layout, ReportLevel level)
            : this()
        {
            this.Layout = layout;
            this.Level = level;
            this.formatter = new MessageFormatter(this.Layout);
        }

        public int Count { get; private set; }

        public ILayout Layout { get; }

        public ReportLevel Level { get; }

        public void Append(IMessage message)
        {
            string formattedMessage = this.formatter.FormatMessage(message);

            Console.WriteLine(formattedMessage);
            this.Count++;
        }
    }
}
