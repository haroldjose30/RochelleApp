using System;
namespace Domain.Core.Commands
{
    public abstract class EntityCommand : Command
    {
        public string Id { get; protected set; }

        public string By { get; protected set; } 
    }
}
