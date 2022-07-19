namespace SoftUniLogger.Appenders.Interfaces
{
    using IO.Interfaces;

    public interface IFileAppender : IAppender
    {
        ILogFile LogFile { get; }

        void SaveLogFile(string filename);
    }
}
