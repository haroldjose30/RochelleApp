using System;
using Framework.Core.Interfaces;
using Framework.Core.Models;
using Framework.Core.Validations;

namespace Framework.Core.Commands
{
    public class RegisterNewGenericCommand<TEntity> : GenericCommand<TEntity> where TEntity : Entity
    {
        IServiceProvider serviceProvider;
        public RegisterNewGenericCommand(TEntity _entity, IServiceProvider _serviceProvider) : base(_entity)
        {
            serviceProvider = _serviceProvider;
        }

        public override bool IsValid()
        {
            try
            {
                //execute action to mark as created register
                entity.Create(entity.Id, entity.CreatedBy, entity.CreatedDate);

                //verify if entity was valid
                ValidationResult = entity.ValidationResult;

                //try to locate specific validator from dependence injection
                IRegisterNewGenericCommandValidation<TEntity> validation = (IRegisterNewGenericCommandValidation<TEntity>)serviceProvider.GetService(typeof(IRegisterNewGenericCommandValidation<TEntity>));

                //if not exists an especific validator, instance default validator
                if (validation == null)
                    validation = new RegisterNewGenericCommandValidation<TEntity>();

                if (validation != null)
                {
                    //execute validation process
                    var ValidationResultAux = validation.Validate(this);

                    //add errors on the default validation result if exists
                    foreach (var item in ValidationResultAux.Errors)
                    {
                        ValidationResult.Errors.Add(item);
                    }
                }

                //return if validation was ok
                return ValidationResult.IsValid;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                ValidationResult = new FluentValidation.Results.ValidationResult();
                ValidationResult.Errors.Add(new FluentValidation.Results.ValidationFailure("RegisterNewGenericCommand", ex.Message));

            }

            return false;


        }

    }



}
