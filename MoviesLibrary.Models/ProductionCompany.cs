using System.Text.Json.Serialization;

namespace MoviesLibrary.Models
{
    public class ProductionCompany
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("logo_path")]
        public string LogoPath { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("origin_country")]
        public string OriginCountry { get; set; }
        //public int id { get; set; }
        //public object logo_path { get; set; }
        //public string name { get; set; }
        //public string origin_country { get; set; }

    }
}
