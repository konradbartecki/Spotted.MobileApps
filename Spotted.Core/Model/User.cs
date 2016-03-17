using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Spotted.Core.Model
{
    public class User
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("token")]
        public string AccessToken { get; set; }

        public Sex Type { get; set; }


        public enum Sex
        {
            Male,
            Female,
            Unknown
        }

    }
}
