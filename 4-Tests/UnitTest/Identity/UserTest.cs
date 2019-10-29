using System;
using Domain.Identity;
using Xunit;

namespace Domain.UnitTest.Identity
{
    public class UserTest
    {
        readonly string companyId = "companyId";
        readonly string createdBy = "createdBy";
        readonly string name = "name";
        readonly string email = "email";
        readonly string login = "login";
        readonly string loginInvalid = "loginInvalid";
        readonly string password = "password";
        readonly string passwordInvalid = "passwordInvalid";
        readonly string customerId = "customerId";



        [Fact]
        public User EntityCreatedAndAllPropertyTested()
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
            return entity;
        }



        [Fact]
        public void LoginIsValidAndInvalid()
        {
            User entity = EntityCreatedAndAllPropertyTested();

            var lLoginAndPasswordIsValid = entity.LoginIsValid(login,password);
            Assert.True(lLoginAndPasswordIsValid);

            var lLoginAndPasswordIsInvalid = entity.LoginIsValid(loginInvalid, passwordInvalid);
            Assert.False(lLoginAndPasswordIsInvalid);

            var lLoginIsValidAndPasswordIsInvalid = entity.LoginIsValid(login, passwordInvalid);
            Assert.False(lLoginAndPasswordIsInvalid);

            var lLoginIsInvalidAndPasswordIsValid = entity.LoginIsValid(loginInvalid, password);
            Assert.False(lLoginAndPasswordIsInvalid);



        }
    }
}
