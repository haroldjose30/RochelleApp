using System;
using System.Collections.Generic;
using Domain.Store;
using Xunit;

namespace Domain.UnitTest.Stores
{
    public class StoreOrderItemTest
    {
        public static IEnumerable<object[]> EntityCreatedAndAllPropertyTestedData =>
          new List<object[]>
          {
                new object[] {"companyId","createdBy", "productId", 4 , 55.4}
          };

        [Theory]
        [MemberData(nameof(EntityCreatedAndAllPropertyTestedData))]
        public static StoreOrderItem EntityCreatedAndAllPropertyTested(string companyId, string createdBy, string productId, Decimal quantity, Decimal valuePoint)
        {
            StoreOrderItem entity = StoreOrderItem.CreateNew(companyId, createdBy, productId, quantity, valuePoint);

            //assert
            Assert.Equal(createdBy, entity.CreatedBy);
            Assert.Equal(companyId, entity.CompanyId);
            Assert.Equal(productId, entity.ProductId);
            Assert.Equal(quantity, entity.Quantity);
            Assert.Equal(valuePoint, entity.ValuePoint);
            return entity;
        }
    }
}
