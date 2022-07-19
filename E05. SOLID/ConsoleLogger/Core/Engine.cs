namespace ConsoleLogger.Core
{
    using System;

    using Factories.Interfaces;
    using Interfaces;
    using SoftUniLogger.Appenders.Interfaces;
    using SoftUniLogger.Enums;
    using SoftUniLogger.Loggers;
    using SoftUniLogger.Loggers.Interfaces;

    internal class Engine : IEngine
    {
        private readonly ILogger logger;
        private readonly IAppenderFactory appenderFactory;

        private Engine()
        {
            this.logger = new Logger();
        }

        public Engine(IAppenderFactory appenderFactory)
            : this()
        {
            this.appenderFactory = appenderFactory;
        }

        public void Start()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                try
                {
                    string[] appenderArgs = Console.ReadLine()
                        .Split();

                    string appenderType = appenderArgs[0];
                    string layoutType = appenderArgs[1];

                    IAppender appender;
                    if (appenderArgs.Length == 2)
                    {
                        appender = this.appenderFactory.Create(appenderType, layoutType);
                    }
                    else
                    {
                        ReportLevel level = Enum.Parse<ReportLevel>(appenderArgs[2], true);
                        appender = this.appenderFactory.Create(appenderType, layoutType, level);
                    }

                    ((IAppenderCollection)this.logger).AddAppender(appender);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] cmdArgs = command
                        .Split('|');
                    string reportLevel = cmdArgs[0].ToUpper();
                    string time = cmdArgs[1];
                    string message = cmdArgs[2];

                    if (reportLevel == "INFO")
                    {
                        this.logger.Info(time, message);
                    }
                    else if (reportLevel == "WARNING")
                    {
                        this.logger.Warning(time, message);
                    }
                    else if (reportLevel == "ERROR")
                    {
                        this.logger.Error(time, message);
                    }
                    else if (reportLevel == "CRITICAL")
                    {
                        this.logger.Critical(time, message);
                    }
                    else if (reportLevel == "FATAL")
                    {
                        this.logger.Fatal(time, message);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
