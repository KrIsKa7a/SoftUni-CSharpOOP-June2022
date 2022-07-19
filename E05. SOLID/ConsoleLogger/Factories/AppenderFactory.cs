namespace ConsoleLogger.Factories
{
    using System;

    using Interfaces;
    using SoftUniLogger.Appenders;
    using SoftUniLogger.Appenders.Interfaces;
    using SoftUniLogger.Enums;
    using SoftUniLogger.IO;
    using SoftUniLogger.IO.Interfaces;
    using SoftUniLogger.Layouts.Interfaces;

    internal class AppenderFactory : IAppenderFactory
    {
        private readonly IFileWriter fw;
        private readonly ILogFile logFile;
        private readonly ILayoutFactory layoutFactory;

        private AppenderFactory()
        {
            this.fw = new FileWriter("../../../Logs");
            this.logFile = new LogFile(fw);
        }

        public AppenderFactory(ILayoutFactory layoutFactory)
            : this()
        {
            this.layoutFactory = layoutFactory;
        }

        public IAppender Create(string type, string layoutType, ReportLevel level = ReportLevel.Info)
        {
            ILayout layout = this.layoutFactory.Create(layoutType);
            IAppender appender;
            if (type == "ConsoleAppender")
            {
                appender = new ConsoleAppender(layout, level);
            }
            else if (type == "FileAppender")
            {
                appender = new FileAppender(layout, level, this.logFile);
            }
            else
            {
                throw new InvalidOperationException("Invalid appender type!");
            }

            return appender;
        }
    }
}
