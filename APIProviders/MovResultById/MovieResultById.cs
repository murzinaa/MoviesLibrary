using System;
using System.Collections.Generic;
using System.Text;

namespace APIProviders.MovResultById
{


    public class MovieResultById
    {
        public bool Adult { get; set; }
        public string BackdropPath { get; set; }
        public object BelongsToCollection { get; set; }
        public int Budget { get; set; }
        public List<Genre> Genres { get; set; }
        public string Homepage { get; set; }
        public string Id { get; set; }
        public string ImdbId { get; set; }
        public string Original_Language { get; set; }
        public string Original_Title { get; set; }
        public string Overview { get; set; }
        public string Popularity { get; set; }
        public string Poster_Path { get; set; }
        public List<ProductionCompany> ProductionCompanies { get; set; }
        public List<ProductionCountry> ProductionCountries { get; set; }
        public string Release_Date { get; set; }
        public int Revenue { get; set; }
        public int Runtime { get; set; }
        public List<SpokenLanguage> SpokenLanguages { get; set; }
        public string Status { get; set; }
        public string Tagline { get; set; }
        public string Title { get; set; }
        public bool Video { get; set; }
        public string Vote_Average { get; set; }
        public string Vote_Count { get; set; }
    }
}
