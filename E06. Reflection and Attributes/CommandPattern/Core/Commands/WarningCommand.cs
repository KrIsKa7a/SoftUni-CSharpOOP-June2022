namespace CommandPattern.Core.Commands
{
    using System;

    using Contracts;

    public class WarningCommand : ICommand
    {
        public string Execute(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            return $"{args[0]}";
        }
    }
}
