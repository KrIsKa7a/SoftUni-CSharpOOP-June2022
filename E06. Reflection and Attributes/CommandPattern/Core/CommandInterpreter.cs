namespace CommandPattern.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Common;
    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] cmdSplit = args
                .Split();
            string cmdName = cmdSplit[0];
            string[] cmdArgs = cmdSplit.Skip(1).ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();
            Type cmdType = assembly?
                .GetTypes()
                .FirstOrDefault(t => t.Name == $"{cmdName}Command" &&
                                     t.GetInterfaces().Any(i => i == typeof(ICommand)));
            if (cmdType == null)
            {
                throw new InvalidOperationException(
                    String.Format(ErrorMessages.InvalidCommandType, $"{cmdName}Command"));
            }

            object cmdInstance = Activator.CreateInstance(cmdType);

            MethodInfo executeMethod = cmdType
                .GetMethods()
                .First(m => m.Name == "Execute");
            string result = (string)executeMethod.Invoke(cmdInstance, new object[] { cmdArgs });

            return result;
        }
    }
}
