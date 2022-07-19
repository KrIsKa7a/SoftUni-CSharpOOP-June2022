namespace SoftUniLogger.IO
{
    using System.IO;
    using System.Text;

    using Interfaces;

    public class FileWriter : IFileWriter
    {
        public FileWriter(string filePath)
        {
            this.FilePath = filePath;
        }

        public string FilePath { get; set; }

        public void WriteContent(string content, string fileName)
        {
            if (!Directory.Exists(this.FilePath))
            {
                Directory.CreateDirectory(this.FilePath);
            }
            string outputPath = Path.Combine(this.FilePath, fileName);
            
            File.WriteAllText(outputPath, content, Encoding.UTF8);
        }
    }
}
