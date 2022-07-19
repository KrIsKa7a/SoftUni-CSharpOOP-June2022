namespace SoftUniLogger.Loggers.Interfaces
{
    using Enums;

    public interface ILogger
    {
        void Info(string logTime, string message);

        void Warning(string logTime, string message);

        void Error(string logTime, string message);

        void Critical(string logTime, string message);

        void Fatal(string logTime, string message);

        void SaveLogs(string fileName);
    }
}
