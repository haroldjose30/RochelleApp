using System;
using Framework.Core.Interfaces;
using Framework.Core.Models;
using Framework.Core.Validations;

namespace Framework.Core.Commands
{
    public class DeleteGenericCommand<TEntity> : GenericCommand<TEntity> where TEntity : Entity, new()
    {
        private readonly IServiceProvider _serviceProvider;

        public DeleteGenericCommand(Guid id, string removedBy, IServiceProvider serviceProvider) : base(new TEntity())
        {
            Entity.Create(removedBy,id);
            _serviceProvider = serviceProvider;
        }

        public override bool IsValid()
        {
            try
            {
                IDeleteGenericCommandValidation<TEntity> validation = (IDeleteGenericCommandValidation<TEntity>)_serviceProvider.GetService(typeof(IDeleteGenericCommandValidation<TEntity>));

                if (validation == null)
                    validation = new DeleteGenericCommandValidation<TEntity>();

                ValidationResult = validation.Validate(this);
                return ValidationResult.IsValid;
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
