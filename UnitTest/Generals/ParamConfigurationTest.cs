using System;
using Domain.Generals;
using Xunit;

namespace Domain.UnitTest.Generals
{
    public class ParamConfigurationTest
    {

        string companyId = "companyId";
        string createdBy = "createdBy";
        string name = "name"; 
        string description = "description";
        string value = "value";
        ParamConfigurationType type = ParamConfigurationType.character;

        [Fact]
        public void EntityCreatedAndAllPropertyTested()
        {
            ParamConfiguration entity = ParamConfiguration.CreateNew(companyId, createdBy, name, description, value, type);

            //assert
            Assert.Equal(createdBy, entity.CreatedBy);
            Assert.Equal(companyId, entity.CompanyId);
            Assert.Equal(name, entity.Name);
            Assert.Equal(description, entity.Description);
            Assert.Equal(value, entity.Value);
            Assert.Equal(type, entity.Type);
        }
    }
}
