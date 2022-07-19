namespace SoftUniLogger.Validators
{
    using System;

    using Interfaces;

    internal class DateTimeValidator : IValidator
    {
        public bool IsValid(object value)
            => DateTime.TryParse((string)value, out DateTime date);
    }
}
