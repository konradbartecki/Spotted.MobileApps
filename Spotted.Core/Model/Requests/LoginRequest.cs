using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Spotted.Core.Model.Interfaces;
using Spotted.Core.Validator;

namespace Spotted.Core.Model.ServiceRequests
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
            CheckModel.Email(Email);
            CheckModel.Password(Password);
        }
    }
}
