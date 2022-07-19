namespace SoftUniLogger.Appenders.Interfaces
{
    using Enums;
    using Layouts.Interfaces;
    using Messages.Interfaces;

    public interface IAppender
    {
        int Count { get; }

        ILayout Layout { get; }

        ReportLevel Level { get; }

        void Append(IMessage message);
    }
}
