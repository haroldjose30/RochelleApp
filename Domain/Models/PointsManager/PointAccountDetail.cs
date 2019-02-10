
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


        public PointAccountDetail(DateTime date, Decimal value, string history, string customerId, string document, PointExtractType pointExtractType, DateTime? expiration ,string companyId, string id, string createdBy, string createdDate, string modifiedBy, string modifiedDate, bool deleted) : base(companyId, id, createdBy, createdDate, modifiedBy, modifiedDate, deleted)
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

       


    }


    public enum PointExtractType
    {
        Automatic,
        Manual
    }
}
