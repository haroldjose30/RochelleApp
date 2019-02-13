using System;
using Domain.Core.Models;

namespace Domain.Core.Validations
{
    public class UpdateGenericCommandValidation<TEntity> : GenericValidation<TEntity> where TEntity : Entity
    {
        public UpdateGenericCommandValidation()
        {
            ValidateId();
            ValidateModifiedBy();
        }


    }
}
