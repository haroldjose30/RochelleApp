using System;
using Domain.Core.Models;

namespace Domain.Core.Events
{
    public abstract class Event<TEntity> : Message where TEntity : Entity
    {
        public TEntity entity { get; private set; }
        public DateTime Timestamp { get; private set; }

        protected Event(TEntity _entity)
        {
            entity = _entity;
            Timestamp = DateTime.Now;
        }
    }

    public abstract class Event : Message
    {
        public DateTime Timestamp { get; private set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}
