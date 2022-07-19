namespace SoftUniLogger.Common
{
    using System.Collections.Generic;

    using Appenders.Interfaces;

    public static class Extensions
    {
        public static void AddRange<T>(this ICollection<T> appenders, IEnumerable<T> appendersToAdd)
        {
            foreach (T apToAdd in appendersToAdd)
            {
                appenders.Add(apToAdd);
            }
        }

        public static IReadOnlyCollection<IAppender> AsReadOnly(this ICollection<IAppender> appenders)
            => (IReadOnlyCollection<IAppender>)appenders;
    }
}
