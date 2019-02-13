using System;
using Domain.Core.Commands;
using Domain.Core.Models;
using FluentValidation;
using FluentValidation.Results;

namespace Domain.Core.Validations
{

    public class RegisterNewGenericCommandValidation<TEntity> : GenericValidation<TEntity> where TEntity : Entity
    {
        public RegisterNewGenericCommandValidation()
        {
            ValidateCreatedBy();
        }


    }
 
}
