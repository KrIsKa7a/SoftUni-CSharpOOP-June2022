namespace CommandPattern.Core
{
    using Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        private readonly IReader reader;
        private readonly IWriter writer;

        public Engine(ICommandInterpreter commandInterpreter, IReader reader, IWriter writer)
        {
            this.commandInterpreter = commandInterpreter;

            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            while (true)
            {
                string input = this.reader.ReadLine();

                string result = this.commandInterpreter.Read(input);
                this.writer.WriteLine(result);
                this.writer.ResetStyle();
            }
        }
    }
}
