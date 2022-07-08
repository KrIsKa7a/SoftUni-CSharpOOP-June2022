namespace Telephony
{
    using Core;
    using IO;
    using IO.Interfaces;

    public class StartUp
    {
        static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            //IReader fileReader = new FileReader("../../../Storage/data.txt");
            //IWriter fileWriter = new FileWriter("../../../Storage/result.txt");

            IEngine engine = new Engine(reader, writer);
            engine.Start();
        }
    }
}
