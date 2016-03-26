using Newtonsoft.Json;
using Spotted.Model.Interfaces;

namespace Spotted.Model.Requests
{
    public class LoginRequest : IValidable
    {
        public LoginRequest()
        {
        }

        public LoginRequest(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }

        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("password")]
        public string Password { get; set; }

        public void CheckValidity()
        {
            ModelValidator.Email(Email);
            ModelValidator.Password(Password);
        }
    }
}
