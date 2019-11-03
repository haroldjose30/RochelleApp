using Domain.Base;
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
      
        
        public bool Create(string companyId, string name, string email, string login, string password,string by)
        {
            Name = name;
            Email = email;
            Login = login;
            Password = password;
            State = RegisterState.Enabled;
            return base.Create(companyId,by);
        }
        
        
        public bool Update(string name, string email, string login, string password, RegisterState state,string by)
        {
            Name = name;
            Email = email;
            Login = login;
            Password = password;
            State = state;
            return base.Update(by);
        }

        public void ProtectPassword()
        {
            this.Password = "******";
        }
    }
}
