using System;
using System.Collections.Generic;
using Domain.Generals;
using Domain.Generals.Base;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace Domain.PointsManager
{
    public class PointAccount : EntityWithCompany
    {
        [JsonProperty]
        public string CustomerId { get; private set; }
        [JsonProperty]
        public Customer Customer { get; private set; }
        [JsonProperty]
        public Decimal Amount { get; private set; }
        [JsonProperty]
        public List<PointAccountDetail> Items { get; private set; }
       
       
        public PointAccount(string customerId, Decimal amount ,string companyId, string id, string createdBy, string createdDate, string modifiedBy, string modifiedDate, bool deleted) : base(companyId, id, createdBy, createdDate, modifiedBy, modifiedDate, deleted)
        {
            this.CustomerId = customerId;
            this.Amount = amount;
            this.Items = new List<PointAccountDetail>();
        }

        public void AddPoints(PointAccountDetail _PointAccountDetail )
        {
            if (_PointAccountDetail.Value <= 0)
            {
                ValidationFailure oValidationFailure = new ValidationFailure("Value", "Valor deve ser maior que zero");
                ValidationResult.Errors.Add(oValidationFailure);

                return;
            }

            this.Items.Add(_PointAccountDetail);
            this.Amount += _PointAccountDetail.Value;
        }

        public void RemovePoints(PointAccountDetail _PointAccountDetail)
        {
            if (_PointAccountDetail.Value >= 0)
            {
                ValidationFailure oValidationFailure = new ValidationFailure("Value", "Valor deve ser menor que zero");
                ValidationResult.Errors.Add(oValidationFailure);

                return;
            }

            this.Items.Add(_PointAccountDetail);
            this.Amount = this.Amount + _PointAccountDetail.Value;
        }

    }
}
