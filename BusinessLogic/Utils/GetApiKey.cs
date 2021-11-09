using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace BusinessLogic.Utils
{
    static class GetApiKey
    {
        public static IConfiguration Configuration { get; }

        //public static string keyValue = Configuration["FilmApiKey"];
    }
}