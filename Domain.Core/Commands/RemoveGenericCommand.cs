using System;
using Domain.Core.Models;
using Domain.Core.Validations;

namespace Domain.Core.Commands
{
    public class RemoveGenericCommand<TEntity> : GenericCommand<TEntity> where TEntity : Entity
    {
        public string Id { get; set; }
        public string RemovedBy { get; set; }

        public RemoveGenericCommand(string id, string removedBy ) : base(null)
        {
            Id = id;
            RemovedBy = removedBy;
        }

        public override bool IsValid()
        {
            return (!string.IsNullOrWhiteSpace(this.Id) && !string.IsNullOrWhiteSpace(this.RemovedBy));
            //ValidationResult = new RemoveGenericCommandValidation<TEntity>().Validate(this);
            //return ValidationResult.IsValid;
        }

    }
}
