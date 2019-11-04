using System;
using Framework.Core.Interfaces;
using Framework.Core.Models;
using Framework.Core.Validations;

namespace Framework.Core.Commands
{
    public class CreateGenericCommand<TEntity> : GenericCommand<TEntity> where TEntity : Entity
    {
        private readonly IServiceProvider _serviceProvider;
        public CreateGenericCommand(TEntity entity, IServiceProvider serviceProvider) : base(entity)
        {
            _serviceProvider = serviceProvider;
        }

        public  override bool IsValid()
        {
            try
            {
                //try to locate specific validator from dependence injection
                ICreateGenericCommandValidation<TEntity> validation =
                    (ICreateGenericCommandValidation<TEntity>) _serviceProvider.GetService(
                        typeof(ICreateGenericCommandValidation<TEntity>));

                //if not exists an custon validator, instance default validator
                if (validation == null)
                    validation = new CreateGenericCommandValidation<TEntity>();

                //execute validation process
                var validationResultAux = validation.Validate(this);

                //add errors on the default validation result if exists
                foreach (var item in validationResultAux.Errors)
                {
                    ValidationResult.Errors.Add(item);
                }

                //return if validation was ok
                return ValidationResult.IsValid;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ValidationResult = new FluentValidation.Results.ValidationResult();
                ValidationResult.Errors.Add(
                    new FluentValidation.Results.ValidationFailure("CreateGenericCommand", ex.Message));

            }

            return false;


        }

    }



}
