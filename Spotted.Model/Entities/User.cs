using Newtonsoft.Json;

namespace Spotted.Model.Entities
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
