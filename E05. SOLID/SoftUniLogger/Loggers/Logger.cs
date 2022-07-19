namespace SoftUniLogger.Loggers
{
    using System.Collections.Generic;

    using Appenders.Interfaces;
    using Common;
    using Enums;
    using Interfaces;
    using Layouts;
    using Messages;
    using Messages.Interfaces;

    public class Logger : IAppenderCollection, ILogger
    {
        private readonly ICollection<IAppender> appenders;

        private Logger()
        {
            this.appenders = new List<IAppender>();
        }

        public Logger(params IAppender[] appenders)
            : this()
        {
            this.appenders.AddRange(appenders);
        }

        public IReadOnlyCollection<IAppender> Appenders
            => this.appenders.AsReadOnly();

        public void AddAppender(IAppender appender)
        {
            this.appenders.Add(appender);
        }

        public bool RemoveAppender(IAppender appender)
        {
            return this.appenders.Remove(appender);
        }

        public void Clear()
        {
            this.appenders.Clear();
        }

        public void Info(string logTime, string message)
        {
            this.LogMessage(logTime, message, ReportLevel.Info);
        }

        public void Warning(string logTime, string message)
        {
            this.LogMessage(logTime, message, ReportLevel.Warning);
        }

        public void Error(string logTime, string message)
        {
            this.LogMessage(logTime, message, ReportLevel.Error);
        }

        public void Critical(string logTime, string message)
        {
            this.LogMessage(logTime, message, ReportLevel.Critical);
        }

        public void Fatal(string logTime, string message)
        {
            this.LogMessage(logTime, message, ReportLevel.Fatal);
        }

        public void SaveLogs(string fileName)
        {
            int cnt = 1;
            foreach (IAppender appender in this.Appenders)
            {
                if (appender is IFileAppender fileAppender)
                {
                    if (fileAppender.Layout.GetType() == typeof(XmlLayout))
                    {
                        fileAppender.SaveLogFile($"{fileName}_{cnt++}.xml");
                    }
                    else
                    {
                        fileAppender.SaveLogFile($"{fileName}_{cnt++}.txt");
                    }
                }
            }
        }

        private void LogMessage(string logTime, string messageText, ReportLevel level)
        {
            IMessage message = new Message(logTime, messageText, level);
            foreach (IAppender appender in this.Appenders)
            {
                if (appender.Level <= level)
                {
                    appender.Append(message);
                }
            }
        }
    }
}
