using System;
using System.Collections.Generic;
using Domain.PointsManager;
using Xunit;

namespace Domain.UnitTest.PointsManager
{
    public static class PointAccountDetailTest
    {
        public static IEnumerable<object[]> EntityCreatedAndAllPropertyTestedData =>
        new List<object[]>
        {
            new object[] {"companyId","createdBy", DateTime.Now, 10.5, "history", "customerId","document", PointExtractType.Automatic, null }
        };

        [Theory]
        [MemberData(nameof(EntityCreatedAndAllPropertyTestedData))]
        public static PointAccountDetail EntityCreatedAndAllPropertyTested(string companyId, string createdBy, DateTime date, Decimal value, string history, string customerId, string document, PointExtractType pointExtractType, DateTime? expiration)
        {
            PointAccountDetail entity = PointAccountDetail.CreateNew(companyId,createdBy,date,value,history,customerId,document,pointExtractType,expiration);

            //assert
            Assert.Equal(createdBy, entity.CreatedBy);
            Assert.Equal(companyId, entity.CompanyId);
            Assert.Equal(customerId, entity.CustomerId);
            Assert.Equal(date, entity.Date);
            Assert.Equal(value, entity.Value);
            Assert.Equal(pointExtractType, entity.PointExtractType);
            Assert.Equal(expiration, entity.Expiration);
            return entity;
        }


       
    }


}
