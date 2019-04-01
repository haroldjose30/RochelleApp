using System;
using Framework.Core.Interfaces;
using Framework.Core.Models;
using Framework.Core.Validations;

namespace Framework.Core.Commands
{
    public class UpdateGenericCommand<TEntity> : GenericCommand<TEntity> where TEntity : Entity
    {
        IServiceProvider serviceProvider;
        public UpdateGenericCommand(TEntity _entity, IServiceProvider _serviceProvider) : base(_entity)
        {
            serviceProvider = _serviceProvider;
        }

        public override bool IsValid()
        {
            try
            {
                IUpdateGenericCommandValidation<TEntity> validation = (IUpdateGenericCommandValidation<TEntity>)serviceProvider.GetService(typeof(IUpdateGenericCommandValidation<TEntity>));

                if (validation == null)
                    validation = new UpdateGenericCommandValidation<TEntity>();

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
                ValidationResult.Errors.Add(new FluentValidation.Results.ValidationFailure("UpdateGenericCommand", ex.Message));

            }

            return false;

        }

    }
}
