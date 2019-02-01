using System;
using Domain.Generals;
using Xunit;

namespace Domain.UnitTest.Generals
{
    public class CustomerTest
    {
        string companyId = "companyId";
        string createdBy = "createdBy";
        string name = "name";
        DateTime birthDate = DateTime.Now;
        string document = "document";
        string email = "email";

        [Fact]
        public void EntityCreatedAndAllPropertyTested()
        {
            Customer entity = Customer.CreateNew(companyId, createdBy, name, birthDate, document, email);

            //assert
            Assert.Equal(createdBy, entity.CreatedBy);
            Assert.Equal(companyId, entity.CompanyId);
            Assert.Equal(name, entity.Name);
            Assert.Equal(birthDate, entity.BirthDate);
            Assert.Equal(document, entity.Document);
            Assert.Equal(email, entity.Email);
        }
    }
}
