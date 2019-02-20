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

            IRegisterNewGenericCommandValidation<TEntity> validation = (IRegisterNewGenericCommandValidation<TEntity>)serviceProvider.GetService(typeof(IRegisterNewGenericCommandValidation<TEntity>));

            if (validation == null)
                validation = new RegisterNewGenericCommandValidation<TEntity>();

                if (validation != null)
            {
                ValidationResult = validation.Validate(this);
                return ValidationResult.IsValid;
            }
            


            return true;
        }

    }



}
