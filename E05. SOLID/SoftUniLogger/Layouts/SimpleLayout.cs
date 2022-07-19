namespace SoftUniLogger.Layouts
{
    using Interfaces;

    //When User try to create a new custom layout, he needs to implement ILayout interface
    public class SimpleLayout : ILayout
    {
        public string Format
            => "{0} - {1} - {2}";
    }
}
