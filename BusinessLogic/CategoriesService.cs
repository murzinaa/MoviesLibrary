using APIProviders;
using BusinessLogic.Interfaces;
using BusinessLogic.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class CategoriesService : ICategoriesService
    {
        public List<string> GetCategoriesByGenre(string url)
        {
            MovieProvider movieProvider = new MovieProvider();
            return movieProvider.GetMovieList(url);
        }
    }
}
