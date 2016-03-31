using System;
using Newtonsoft.Json;
using Spotted.Model.Enums;

namespace Spotted.Model.Entities
{
    public class User
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        public Gender Gender { get; set; }
    }
}
