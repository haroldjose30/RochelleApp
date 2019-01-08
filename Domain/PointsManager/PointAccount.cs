using System;
using System.Collections.Generic;
using Domain.Generals;
using Domain.Generals.Base;
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

        public PointAccount(string companyId, string id, string createdBy, string customerId, Decimal amount) : base(companyId, id, createdBy)
        {
            this.CustomerId = customerId;
            this.Amount = amount;
            this.Items = new List<PointAccountDetail>();
        }

        public static PointAccount CreateNew(string companyId, string createdBy, string customerId) 
        {
            Decimal amount = 0;
            PointAccount oPointAccount = new PointAccount(companyId, string.Empty, createdBy, customerId, amount);
            return oPointAccount;
        }

        public void AddPoints(PointAccountDetail _PointAccountDetail)
        {
            if (_PointAccountDetail.Value <= 0)
                throw new Exception("Valor deve ser maior que zero");

            this.Items.Add(_PointAccountDetail);
            this.Amount += _PointAccountDetail.Value;
        }

        public void RemovePoints(PointAccountDetail _PointAccountDetail)
        {
            if (_PointAccountDetail.Value >= 0)
                throw new Exception("Valor deve ser menor que zero");

            this.Items.Add(_PointAccountDetail);
            this.Amount = this.Amount + _PointAccountDetail.Value;
        }

    }
}
