namespace SoftUniLogger.Formatters.Interfaces
{
    using Layouts.Interfaces;
    using Messages.Interfaces;

    internal interface IFormatter
    {
        ILayout Layout { get; }

        string FormatMessage(IMessage message);
    }
}
