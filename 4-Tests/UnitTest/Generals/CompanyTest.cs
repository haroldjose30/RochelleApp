using System;
using Domain.Generals;
using Xunit;

namespace Domain.UnitTest.Generals
{
    public class CompanyTest
    {
        readonly string createdBy = "user";
        readonly string company = "company";
        readonly string fantasy = "fantasy";
        readonly string corporateNumber = "number";
        readonly string stateRegistration = "stateregistration";
        readonly string state = "state";
        readonly string address = "address";
        readonly string district = "district";
        readonly string complement = "complement";
        readonly string city = "city";
        readonly string zipcode = "zipcode";
        readonly string phone = "phone";

        [Fact]
        public void EntityCreatedAndAllPropertyTested()
        {
            Company entity = Company.CreateNew(createdBy,company,fantasy, corporateNumber,stateRegistration,address,district,complement, state,city,zipcode,phone);

            //assert
            Assert.Equal(createdBy, entity.CreatedBy);
            Assert.Equal(company, entity.CompanyName);
            Assert.Equal(fantasy, entity.FantasyName);
            Assert.Equal(corporateNumber, entity.CorporateNumber);
            Assert.Equal(state, entity.State);
            Assert.Equal(address, entity.Address);
            Assert.Equal(district, entity.District);
            Assert.Equal(complement, entity.Complement);
            Assert.Equal(stateRegistration, entity.StateRegistration);
            Assert.Equal(city, entity.City);
            Assert.Equal(zipcode, entity.ZipCode);
            Assert.Equal(phone, entity.Phone);
        }



    }
}
