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
        private readonly IApiMovieProvider _apiMovieProvider;

        public CategoriesService(IApiMovieProvider apiMovieProvider)
        {
            _apiMovieProvider = apiMovieProvider;
        }
        public async Task<MovieResult> GetCategoriesByGenre(string url) => await _apiMovieProvider.GetMovieList(url);
    }
}
