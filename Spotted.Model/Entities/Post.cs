using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Spotted.Model.Entities
{
    public class Post
    {
        [JsonProperty("_id")]
        public string Id { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime Created { get; set; }
        [JsonProperty("author")]
        public string AuthorId { get; set; }

        public override string ToString()
        {
            return Description ?? string.Empty;
        }
    }
}
