namespace SoftUniLogger.Appenders
{
    using Enums;
    using Formatters;
    using Formatters.Interfaces;
    using Interfaces;
    using IO.Interfaces;
    using Layouts.Interfaces;
    using Messages.Interfaces;

    public class FileAppender : IFileAppender
    {
        private readonly IFormatter formatter;

        private FileAppender()
        {
            this.Count = 0;
        }

        public FileAppender(ILayout layout, ReportLevel level, ILogFile logFile)
            : this()
        {
            this.Layout = layout;
            this.Level = level;
            this.LogFile = logFile;
            this.formatter = new MessageFormatter(this.Layout);
        }

        public int Count { get; }

        public ILayout Layout { get; }

        public ReportLevel Level { get; }

        public ILogFile LogFile { get; }

        public void Append(IMessage message)
        {
            string formattedMessage = this.formatter.FormatMessage(message);
            this.LogFile.Write(formattedMessage);
        }

        public void SaveLogFile(string filename)
        {
            this.LogFile.SaveAs(filename);
        }
    }
}
