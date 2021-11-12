using APIProviders;
using BusinessLogic.Interfaces;
using BusinessLogic.Utils;
using MoviesLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class CategoriesService : ICategoriesService
    {
        public async Task<MovieResult> GetCategoriesByGenre(string url)
        {
            MovieProvider movieProvider = new MovieProvider();
            return await movieProvider.GetMovieList(url);
        }
    }
}
