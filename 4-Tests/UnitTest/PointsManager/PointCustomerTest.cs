using System;
using System.Collections.Generic;
using Domain.PointsManager;
using Xunit;

namespace Domain.UnitTest.PointsManager
{
    public class PointCustomerTest
    {
        public static IEnumerable<object[]> EntityCreatedAndAllPropertyTestedData =>
        new List<object[]>
        {
            new object[] {"companyId","createdBy","customerId",5}
        };

        [Theory]
        [MemberData(nameof(EntityCreatedAndAllPropertyTestedData))]
        public static PointCustomer EntityCreatedAndAllPropertyTested(string companyId, string createdBy, string customerId, int invitesQuantity)
        {
            PointCustomer entity = PointCustomer.CreateNew(companyId, createdBy, customerId, invitesQuantity);

            //assert
            Assert.Equal(createdBy, entity.CreatedBy);
            Assert.Equal(companyId, entity.CompanyId);
            Assert.Equal(customerId, entity.CustomerId);
            Assert.Equal(invitesQuantity, entity.InvitesQuantity);
            return entity;
        }



    }


}


