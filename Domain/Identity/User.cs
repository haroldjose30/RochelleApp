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

        public User(string companyId, string id, string createdBy, string name, string email, string login, string password, RegisterState state, string customerId) : base(companyId, id, createdBy)
        {
            Name = name;
            Email = email;
            Login = login;
            Password = password;
            State = state;
            CustomerId = customerId;
            //Customer = customer;
        }


        public static User CreateNew(string companyId, string createdBy, string name, string email, string login, string password, string customerId)
        {
            RegisterState state = RegisterState.Enabled;
            User oUser = new User(companyId,string.Empty, createdBy, name, email, login, password,state, customerId);
            return oUser;
        }

        public bool LoginIsValid(string cLogin,string cPassword)
        {
            return this.Login.Equals(cLogin) && this.Password.Equals(cPassword);
        }


    }


}
