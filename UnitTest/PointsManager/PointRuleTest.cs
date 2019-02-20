using System;
using System.Collections.Generic;
using Domain.PointsManager;
using Xunit;

namespace Domain.UnitTest.PointsManager
{
    public class PointRuleTest
    {
        public static IEnumerable<object[]> EntityCreatedAndAllPropertyTestedData =>
        new List<object[]>
        {
            new object[] {"companyId","createdBy", "name", 5.5, PointRuleType.None}
        };

        [Theory]
        [MemberData(nameof(EntityCreatedAndAllPropertyTestedData))]
        public static PointRule EntityCreatedAndAllPropertyTested(string companyId, string createdBy, string name, double pointToGain, PointRuleType pointRuleType)
        {
            PointRule entity = PointRule.CreateNew(companyId, createdBy, name, pointToGain,pointRuleType);

            //assert
            Assert.Equal(createdBy, entity.CreatedBy);
            Assert.Equal(companyId, entity.CompanyId);
            Assert.Equal(name, entity.Name);
            Assert.Equal(pointToGain, entity.PointToGain);
            Assert.Equal(pointRuleType, entity.PointRuleType);
            return entity;
        }
    }
}
