using Domain.Generals;
using Domain.Generals.Base;
using Newtonsoft.Json;

namespace Domain.Identity
{

    public class User:EntityWithCompany
    {
       

        [JsonProperty]
        public string Name { get; private set; }
        [JsonProperty]
        public string Email { get; private set; }
        [JsonProperty]
        public string Login { get; private set; }
        [JsonProperty]
        public string Password { get; private set; }
        [JsonProperty]
        public RegisterState State { get; private set; }
        [JsonProperty]
        public string CustomerId { get; private set; }
        [JsonProperty]
        public Customer Customer { get; private set; }


        public User(string name, string email, string login, string password, RegisterState state, string customerId,string companyId, string id, string createdBy, string createdDate, string modifiedBy, string modifiedDate, bool deleted) : base(companyId, id, createdBy, createdDate, modifiedBy, modifiedDate, deleted)
        {
            Name = name;
            Email = email;
            Login = login;
            Password = password;
            State = state;
            CustomerId = customerId;
            //Customer = customer;
        }
       
        public bool LoginIsValid(string cLogin,string cPassword)
        {
            return this.Login.Equals(cLogin) && this.Password.Equals(cPassword);
        }


    }
     


}
