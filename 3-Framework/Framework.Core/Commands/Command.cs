using System;
using FluentValidation.Results;

namespace Framework.Core.Commands
{
    public abstract class Command : MessageRequest
    {
        public DateTime Timestamp { get; }
        public ValidationResult ValidationResult { get; set; } = new ValidationResult();

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public abstract bool IsValid();
    }
}
