using System;
using Domain.Core.Events;
using FluentValidation.Results;

namespace Domain.Core.Commands
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
