using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MoviesLibrary.Models
{
    public class TrendingMoviesResult
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("results")]
        public List<TrendingMoviesFullResult> Results { get; set; }

        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("total_results")]
        public int TotalResults { get; set; }
    }
}
