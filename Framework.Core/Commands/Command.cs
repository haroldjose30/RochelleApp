using System;
using Framework.Core.Events;
using FluentValidation.Results;

namespace Framework.Core.Commands
{
    public abstract class Command : MessageRequest
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public abstract bool IsValid();
    }
}
