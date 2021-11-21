using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MoviesLibrary.Models
{
    public class Videos
    {
        [JsonPropertyName("results")]
        public List<VideoResult> Results { get; set; }
    }

}
