namespace CommandPattern.IO.Contracts
{
    public interface IWriter
    {
        void Write(string value);

        void WriteLine(string value);

        void ResetStyle();
    }
}
