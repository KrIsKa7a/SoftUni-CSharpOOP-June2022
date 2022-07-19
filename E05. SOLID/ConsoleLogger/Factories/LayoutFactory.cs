namespace ConsoleLogger.Factories
{
    using System;

    using Interfaces;
    using SoftUniLogger.Layouts;
    using SoftUniLogger.Layouts.Interfaces;

    internal class LayoutFactory : ILayoutFactory
    {
        public ILayout Create(string type)
        {
            ILayout layout;
            if (type == "SimpleLayout")
            {
                layout = new SimpleLayout();
            }
            else if (type == "XmlLayout")
            {
                layout = new XmlLayout();
            }
            else
            {
                throw new InvalidOperationException("Invalid layout type!");
            }

            return layout;
        }
    }
}
