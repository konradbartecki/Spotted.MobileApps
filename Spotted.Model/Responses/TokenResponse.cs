using Newtonsoft.Json;

namespace Spotted.Model.Responses
{
    public class TokenResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
