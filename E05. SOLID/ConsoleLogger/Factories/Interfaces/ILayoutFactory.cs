namespace ConsoleLogger.Factories.Interfaces
{
    using SoftUniLogger.Layouts.Interfaces;

    internal interface ILayoutFactory
    {
        ILayout Create(string type);
    }
}
