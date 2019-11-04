using System;
using Framework.Core.Interfaces;
using Framework.Core.Models;
using Framework.Core.Validations;

namespace Framework.Core.Commands
{
    public class UpdateGenericCommand<TEntity> : GenericCommand<TEntity> where TEntity : Entity
    {
        private readonly IServiceProvider _serviceProvider;
        public UpdateGenericCommand(TEntity entity, IServiceProvider serviceProvider) : base(entity)
        {
            this._serviceProvider = serviceProvider;
        }

        public override bool IsValid()
        {
            try
            {
                IUpdateGenericCommandValidation<TEntity> validation = (IUpdateGenericCommandValidation<TEntity>)_serviceProvider.GetService(typeof(IUpdateGenericCommandValidation<TEntity>));

                if (validation == null)
                    validation = new UpdateGenericCommandValidation<TEntity>();

                ValidationResult = validation.Validate(this);
                return ValidationResult.IsValid;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ValidationResult = new FluentValidation.Results.ValidationResult();
                ValidationResult.Errors.Add(new FluentValidation.Results.ValidationFailure("UpdateGenericCommand", ex.Message));

            }

            return false;

        }

    }
}
