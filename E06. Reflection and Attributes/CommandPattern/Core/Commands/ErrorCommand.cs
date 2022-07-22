namespace CommandPattern.Core.Commands
{
    using System;

    using Contracts;

    public class ErrorCommand : ICommand
    {
        public string Execute(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            return $"{args[0]}";
        }
    }
}
