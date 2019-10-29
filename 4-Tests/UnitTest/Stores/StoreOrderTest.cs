using System;
using System.Collections.Generic;
using Domain.Store;
using Xunit;

namespace Domain.UnitTest.Stores
{
    public class StoreOrderTest
    {
        public static IEnumerable<object[]> EntityCreatedAndAllPropertyTestedData =>
       new List<object[]>
       {
            new object[] {"companyId","createdBy",DateTime.Now, "customerFromId" }
       };

        [Theory]
        [MemberData(nameof(EntityCreatedAndAllPropertyTestedData))]
        public static StoreOrder EntityCreatedAndAllPropertyTested(string companyId, string createdBy, DateTime date, string customerFromId)
        {
            StoreOrder entity = StoreOrder.CreateNew( companyId,  createdBy,  date,  customerFromId);

            //assert
            Assert.Equal(createdBy, entity.CreatedBy);
            Assert.Equal(companyId, entity.CompanyId);
            Assert.Equal(date, entity.Date);
            Assert.Equal(customerFromId, entity.CustomerFromId);
            return entity;
        }
    }
}
