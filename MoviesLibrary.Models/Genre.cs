using System.Text.Json.Serialization;

namespace MoviesLibrary.Models
{
    public class Genre
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        //public int id { get; set; }
        //public string name { get; set; }
    }
}
