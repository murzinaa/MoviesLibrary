using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Utils
{
    public class Constants
    {
        public static readonly string apikey = "efc923dfbeb80bd974570be62f1057bc";//GetApiKey.keyValue;
        public static class FilmApiUrls
        {

            public static string ReturnUrl(int genre)
            {
                return $"https://api.themoviedb.org/3/discover/movie?api_key={apikey}&with_genres={genre}&page=1";
            }

            public static string ReturnUrlForMovieResult(string movie)
            {
                return $"https://api.themoviedb.org/3/movie/{movie}?api_key={apikey}";
            }

            public static string ReturnUrlForSearch(string title)
            {
                return $"https://api.themoviedb.org/3/search/movie?query={title}&api_key={apikey}";
            }
        }
    }
}
