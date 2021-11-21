﻿namespace MoviesLibrary.BusinessLogic.Utils
{
    public class Constants
    {
        public static readonly string apikey = "efc923dfbeb80bd974570be62f1057bc";//GetApiKey.keyValue;
        public static class FilmApiUrls
        {

            public static string ReturnUrl(int genre, int page)
            {
                return $"https://api.themoviedb.org/3/discover/movie?api_key={apikey}&with_genres={genre}&page={page}";
            }

            public static string ReturnUrlForMovieResult(string movie)
            {
                return $"https://api.themoviedb.org/3/movie/{movie}?api_key={apikey}&append_to_response=videos";
                //return $"https://api.themoviedb.org/3/movie/{movie}?api_key={apikey}";
            }

            public static string ReturnUrlForSearch(string title, int page)
            {
                return $"https://api.themoviedb.org/3/search/movie?query={title}&api_key={apikey}&page={page}";

            }
            public static string ResturnUrlForTrending(int page)
            {
                return $"https://api.themoviedb.org/3/trending/movie/day?api_key={apikey}&page={page}";
            }
        }
    }
}
