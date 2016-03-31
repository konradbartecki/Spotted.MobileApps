using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Spotted.Model.Interfaces;

namespace Spotted.Model.Entities
{
    public class Post : IGeolocated
    {
        [JsonProperty("_id")]
        public string Id { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime Created { get; set; }
        [JsonProperty("author")]
        public string AuthorId { get; set; }
        [JsonProperty("ignore123")]
        public BasicGroup Group { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
