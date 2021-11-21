﻿using System.Text.Json.Serialization;

namespace MoviesLibrary.Models
{
    public class SpokenLanguage
    {
        [JsonPropertyName("english_name")]
        public string EnglishName { get; set; }

        [JsonPropertyName("iso_639_1")]
        public string Iso6391 { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
        //public string english_name { get; set; }
        //public string iso_639_1 { get; set; }
        //public string name { get; set; }
    }
}
