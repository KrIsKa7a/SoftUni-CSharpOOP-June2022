namespace SoftUniLogger.Formatters
{
    using System;

    using Interfaces;
    using Layouts.Interfaces;
    using Messages.Interfaces;

    internal class MessageFormatter : IFormatter
    {
        public MessageFormatter(ILayout layout)
        {
            this.Layout = layout;
        }

        public ILayout Layout { get; }

        public string FormatMessage(IMessage message)
            => String.Format(this.Layout.Format,
                message.LogTime, message.Level.ToString(), message.MessageText);
    }
}
