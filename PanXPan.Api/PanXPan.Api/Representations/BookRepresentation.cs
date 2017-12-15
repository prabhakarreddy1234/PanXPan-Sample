using Newtonsoft.Json;
using System;

namespace PanXPan.Api.Representations
{
    public class BookRepresentation
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        [JsonRequired]
        public string Name { get; set; }

        [JsonProperty("numberOfPages")]
        public int NumberOfPages { get; set; }

        [JsonProperty("dateOfPublication")]
        [JsonRequired]
        public DateTime DateOfPublication { get; set; }

        [JsonProperty("authors")]
        public string[] Authors { get; set; }
    }
}