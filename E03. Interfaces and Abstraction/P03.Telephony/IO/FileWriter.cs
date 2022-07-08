namespace Telephony.IO
{
    using System;
    using System.IO;

    using Interfaces;

    public class FileWriter : IWriter
    {
        private string fileContent;

        public FileWriter(string filepath)
        {
            this.FilePath = filepath;
            this.fileContent = File.ReadAllText(filepath);
        }

        public string FilePath { get; set; }

        public void Write(string text)
        {
            string output = this.fileContent + text;
            File.WriteAllText(this.FilePath, output);
            this.fileContent = output;
        }

        public void WriteLine(string text)
        {
            string output = this.fileContent + Environment.NewLine + text;
            File.WriteAllText(this.FilePath, output);
            this.fileContent = output;
        }
    }
}
