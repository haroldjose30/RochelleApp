using System;
using Domain.PointsManager;
using Xunit;

namespace Domain.UnitTest.PointsManager
{
    public class InviteTest
    {

        string companyId = "companyId";
        string createdBy = "createdBy";
        string customerFromId = "customerFromId";
        string customerToId = "customerToId";

        [Fact]
        public void EntityCreatedAndAllPropertyTested()
        {
            Invite entity = Invite.CreateNew(companyId, createdBy, customerFromId, customerToId);

            //assert
            Assert.Equal(createdBy, entity.CreatedBy);
            Assert.Equal(companyId, entity.CompanyId);
            Assert.Equal(customerFromId, entity.CustomerFromId);
            Assert.Equal(customerToId, entity.CustomerToId);        

        }
    }
}
