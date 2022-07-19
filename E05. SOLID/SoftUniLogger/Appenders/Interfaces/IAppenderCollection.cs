namespace SoftUniLogger.Appenders.Interfaces
{
    using System.Collections.Generic;

    public interface IAppenderCollection
    {
        IReadOnlyCollection<IAppender> Appenders { get; }

        void AddAppender(IAppender appender);

        bool RemoveAppender(IAppender appender);

        void Clear();
    }
}
