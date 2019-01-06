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
        public double Amount { get; private set; } = 0;
        [JsonProperty]
        public List<PointAccountDetail> pointAccountDetail { get; private set; }

        public PointAccount(string companyId, string id, string createdBy, string customerId, double amount) : base(companyId, id, createdBy)
        {
            this.CustomerId = CustomerId;
            this.Amount = amount;
            this.pointAccountDetail = new List<PointAccountDetail>();
        }

        public static PointAccount CreateNew(string companyId, string createdBy, string customerId, double amount) 
        {
            PointAccount oPointAccount = new PointAccount(companyId, string.Empty, createdBy, customerId, amount);
            return oPointAccount;
        }

        public PointAccountDetail AddPoints(string companyId, string createdBy, DateTime date, double value, string history, string customerId, string document, PointExtractType pointExtractType)
        {
            if (value <= 0)
                throw new Exception("Valor deve ser maior que zero");


            PointAccountDetail oPointAccountDetail = new PointAccountDetail(companyId, String.Empty, createdBy, date, value, history, customerId, document, pointExtractType, null);
            this.pointAccountDetail.Add(oPointAccountDetail);
            this.Amount += value;
            return oPointAccountDetail;
        }

        public PointAccountDetail RemovePoints(string companyId, string createdBy, DateTime date, double value, string history, string customerId, string document, PointExtractType pointExtractType)
        {
            if (value >= 0)
                throw new Exception("Valor deve ser menor que zero");

            PointAccountDetail oPointAccountDetail = new PointAccountDetail(companyId, String.Empty, createdBy, date, value, history, customerId, document, pointExtractType, null);
            this.pointAccountDetail.Add(oPointAccountDetail);
            this.Amount -= value;
            return oPointAccountDetail;
        }

    }
}
