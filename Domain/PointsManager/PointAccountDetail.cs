using System;
using Domain.Generals;
using Domain.Generals.Base;
using Newtonsoft.Json;

namespace Domain.PointsManager
{
    public class PointAccountDetail:EntityWithCompany
    {

        [JsonProperty]
        public DateTime Date { get; private set; }
        [JsonProperty]
        public Decimal Value { get; private set; }
        [JsonProperty]
        public string History { get; private set; }
        [JsonProperty]
        public string CustomerId { get; private set; }
        [JsonProperty]
        public Customer Customer { get; private set; }
        [JsonProperty]
        public string Document { get; private set; }
        [JsonProperty]
        public PointExtractType PointExtractType { get; private set; }
        [JsonProperty]
        public DateTime? Expiration { get; private set; }


        public PointAccountDetail(string companyId, string id, string createdBy,DateTime date, Decimal value, string history, string customerId, string document, PointExtractType pointExtractType, DateTime? expiration) : base(companyId, id, createdBy)
        {
            Date = date;
            Value = value;
            History = history;
            CustomerId = customerId;
            //Customer = customer;
            Document = document;
            PointExtractType = pointExtractType;
            Expiration = expiration;
        }

        public static PointAccountDetail CreateNew(string companyId, string createdBy, DateTime date, Decimal value, string history, string customerId, string document, PointExtractType pointExtractType, DateTime? expiration) 
        {
            PointAccountDetail oPointAccountDetail = new PointAccountDetail(companyId, string.Empty, createdBy, date, value, history, customerId, document, pointExtractType,  null);
            return oPointAccountDetail;
        }


    }


    public enum PointExtractType
    {
        Automatic,
        Manual
    }
}
