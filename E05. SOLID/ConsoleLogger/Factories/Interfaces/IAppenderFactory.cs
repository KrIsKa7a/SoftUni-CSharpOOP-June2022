namespace ConsoleLogger.Factories.Interfaces
{
    using SoftUniLogger.Appenders.Interfaces;
    using SoftUniLogger.Enums;

    internal interface IAppenderFactory
    {
        IAppender Create(string type, string layoutType, ReportLevel level = ReportLevel.Info);
    }
}
