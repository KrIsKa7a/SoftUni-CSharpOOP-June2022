namespace CommandPattern.Core.Commands
{
    using Contracts;

    public class InfoCommand : ICommand
    {
        public string Execute(string[] args)
        {
            return $"My name is {args[0]} and I am {args[1]} years old!";
        }
    }
}
