namespace SoftUniLogger.Messages.Interfaces
{
    using Enums;

    public interface IMessage
    {
        string LogTime { get; }

        string MessageText { get; }

        ReportLevel Level { get; }
    }
}
