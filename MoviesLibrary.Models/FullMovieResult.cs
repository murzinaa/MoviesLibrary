using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MoviesLibrary.Models
{


    public class FullMovieResult
    {
        [JsonPropertyName("adult")]
        public bool Adult { get; set; }

        [JsonPropertyName("backdrop_path")]
        public string BackdropPath { get; set; }

        [JsonPropertyName("belongs_to_collection")]
        public object BelongsToCollection { get; set; }

        [JsonPropertyName("budget")]
        public int Budget { get; set; }

        [JsonPropertyName("genres")]
        public List<Genre> Genres { get; set; }

        [JsonPropertyName("homepage")]
        public string Homepage { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("imdb_id")]
        public string ImdbId { get; set; }

        [JsonPropertyName("original_language")]
        public string OriginalLanguage { get; set; }

        [JsonPropertyName("original_title")]
        public string OriginalTitle { get; set; }

        [JsonPropertyName("overview")]
        public string Overview { get; set; }

        [JsonPropertyName("popularity")]
        public double Popularity { get; set; }

        [JsonPropertyName("poster_path")]
        public string PosterPath { get; set; }

        [JsonPropertyName("production_companies")]
        public List<ProductionCompany> ProductionCompanies { get; set; }

        [JsonPropertyName("production_countries")]
        public List<ProductionCountry> ProductionCountries { get; set; }

        [JsonPropertyName("release_date")]
        public string ReleaseDate { get; set; }

        [JsonPropertyName("revenue")]
        public int Revenue { get; set; }

        [JsonPropertyName("runtime")]
        public int Runtime { get; set; }

        [JsonPropertyName("spoken_languages")]
        public List<SpokenLanguage> SpokenLanguages { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("tagline")]
        public string Tagline { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("video")]
        public bool Video { get; set; }

        [JsonPropertyName("vote_average")]
        public double VoteAverage { get; set; }

        [JsonPropertyName("vote_count")]
        public int VoteCount { get; set; }

        [JsonPropertyName("videos")]
        public Videos Videos { get; set; }
        //public bool adult { get; set; }
        //public string backdrop_path { get; set; }
        //public object belongs_to_collection { get; set; }
        //public double budget { get; set; }
        //public List<Genre> genres { get; set; }
        //public string homepage { get; set; }
        //public int id { get; set; }
        //public string imdb_id { get; set; }
        //public string original_language { get; set; }
        //public string original_title { get; set; }
        //public string overview { get; set; }
        //public double popularity { get; set; }
        //public string poster_path { get; set; }
        //public List<ProductionCompany> production_companies { get; set; }
        //public List<ProductionCountry> production_countries { get; set; }
        //public string release_date { get; set; }
        //public double revenue { get; set; }
        //public int runtime { get; set; }
        //public List<SpokenLanguage> spoken_languages { get; set; }
        //public string status { get; set; }
        //public string tagline { get; set; }
        //public string title { get; set; }
        //public bool video { get; set; }
        //public double vote_average { get; set; }
        //public int vote_count { get; set; }

    }
}
