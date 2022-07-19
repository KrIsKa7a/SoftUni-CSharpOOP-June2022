namespace ConsoleLogger
{
    using Core;
    using Core.Interfaces;
    using Factories;
    using Factories.Interfaces;

    public class StartUp
    {
        static void Main(string[] args)
        {
            //This won't be responsibility of the user
            //Implementing Logger will correct this!
            ILayoutFactory layoutFactory = new LayoutFactory();
            IAppenderFactory appenderFactory = new AppenderFactory(layoutFactory);

            IEngine engine = new Engine(appenderFactory);
            engine.Start();
        }
    }
}
