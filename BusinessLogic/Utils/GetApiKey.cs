using Microsoft.Extensions.Configuration;

namespace MoviesLibrary.BusinessLogic.Utils
{
    static class GetApiKey
    {
        public static IConfiguration Configuration { get; }

        //public static string keyValue = Configuration["FilmApiKey"];
    }
}