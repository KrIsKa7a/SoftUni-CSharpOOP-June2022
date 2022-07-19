namespace SoftUniLogger.IO
{
    using System.Text;

    using Interfaces;

    public class LogFile : ILogFile
    {
        private readonly StringBuilder sbContent;
        private readonly IFileWriter fileWriter;

        private LogFile()
        {
            this.sbContent = new StringBuilder();
        }

        public LogFile(IFileWriter fileWriter)
            : this()
        {
            this.fileWriter = fileWriter;
        }

        public int Size
            => this.sbContent.Length;

        public string Content
            => this.sbContent.ToString();

        public void Write(string content)
        {
            this.sbContent.AppendLine(content);
        }

        public void SaveAs(string filename)
        {
            this.fileWriter.WriteContent(this.Content, filename);
        }
    }
}
