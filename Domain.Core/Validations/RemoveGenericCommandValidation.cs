using System;
using Domain.Core.Models;

namespace Domain.Core.Validations
{
    public class RemoveGenericCommandValidation<TEntity> : GenericValidation<TEntity> where TEntity : Entity
    {
        public RemoveGenericCommandValidation()
        {
            ValidateId();
            ValidateModifiedBy();
        }

    }
}
