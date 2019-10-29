using System;
using Framework.Core.Interfaces;
using Framework.Core.Models;
using Framework.Core.Validations;

namespace Framework.Core.Commands
{
    public class RemoveGenericCommand<TEntity> : GenericCommand<TEntity> where TEntity : Entity, new()
    {
        //public string Id { get; set; }
        //public string RemovedBy { get; set; }
        IServiceProvider serviceProvider;

        public RemoveGenericCommand(string id, string removedBy, IServiceProvider _serviceProvider) : base(new TEntity())
        {
            //this.Entity = new TEntity();
            entity.Create(id, removedBy, "");

            //Id = id;
            //RemovedBy = removedBy;
            serviceProvider = _serviceProvider;
        }

        public override bool IsValid()
        {
            try
            {
                IRemoveGenericCommandValidation<TEntity> validation = (IRemoveGenericCommandValidation<TEntity>)serviceProvider.GetService(typeof(IRemoveGenericCommandValidation<TEntity>));

                if (validation == null)
                    validation = new RemoveGenericCommandValidation<TEntity>();

                if (validation != null)
                {
                    ValidationResult = validation.Validate(this);
                    return ValidationResult.IsValid;
                }

                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ValidationResult = new FluentValidation.Results.ValidationResult();
                ValidationResult.Errors.Add(new FluentValidation.Results.ValidationFailure("RemoveGenericCommand", ex.Message));

            }

            return false;
           

        }

    }
}
