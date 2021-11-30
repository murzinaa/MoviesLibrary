using MoviesLibrary.BusinessLogic.Services;

namespace MoviesLibrary.BusinessLogic.Utils
{
    public class Constants
    {
        public static class FilmApiUrls
        {
            public static string ReturnUrl(int genre, int page, string apikey)
            {
                return $"https://api.themoviedb.org/3/discover/movie?api_key={apikey}&with_genres={genre}&page={page}&adult=false";
            }

            public static string ReturnUrlForMovieResult(string movie, string apikey)
            {
                return $"https://api.themoviedb.org/3/movie/{movie}?api_key={apikey}&append_to_response=videos";
            }

            public static string ReturnUrlForSearch(string title, int page, string apikey)
            {
                return $"https://api.themoviedb.org/3/search/movie?query={title}&api_key={apikey}&page={page}";

            }
            public static string ResturnUrlForTrending(int page, string apikey)
            {
                return $"https://api.themoviedb.org/3/trending/movie/day?api_key={apikey}&page={page}";
            }
        }
    }
}
