using System;
using System.Collections.Generic;
using Domain.Store;
using Xunit;

namespace Domain.UnitTest.Stores
{
    public class StoreProductTest
    {
        public static IEnumerable<object[]> EntityCreatedAndAllPropertyTestedData =>
           new List<object[]>
           {
                new object[] {"companyId","id","createdBy", 55.5,33.3 }
           };

        [Theory]
        [MemberData(nameof(EntityCreatedAndAllPropertyTestedData))]
        public static StoreProduct EntityCreatedAndAllPropertyTested(string companyId, string id, string createdBy, Decimal valuePoint, Decimal valueMoney)
        {
            StoreProduct entity = StoreProduct.CreateNew(companyId, id,createdBy, valuePoint, valueMoney);

            //assert
            Assert.Equal(createdBy, entity.CreatedBy);
            Assert.Equal(companyId, entity.CompanyId);
            Assert.Equal(id, entity.Id);
            Assert.Equal(createdBy, entity.CreatedBy);
            Assert.Equal(valuePoint, entity.ValuePoint);
            Assert.Equal(valueMoney, entity.ValueMoney);
            return entity;
        }
    }
}
