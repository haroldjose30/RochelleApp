using System;
using Domain.Identity;
using Xunit;

namespace Domain.UnitTest.Identity
{
    public class UserTest
    {
        string companyId = "companyId"; 
        string createdBy = "createdBy";
        string name = "name";
        string email = "email";
        string login = "login";
        string password = "password";
        string customerId = "customerId";

        [Fact]
        public void EntityCreatedAndAllPropertyTested()
        {
            User entity = User.CreateNew(companyId, createdBy, name, email, login, password, customerId);

            //assert
            Assert.Equal(createdBy, entity.CreatedBy);
            Assert.Equal(companyId, entity.CompanyId);
            Assert.Equal(name, entity.Name);
            Assert.Equal(email, entity.Email);
            Assert.Equal(login, entity.Login);
            Assert.Equal(password, entity.Password);
            Assert.Equal(customerId, entity.CustomerId);
        }
    }
}
