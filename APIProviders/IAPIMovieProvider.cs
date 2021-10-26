using MoviesLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APIProviders
{
    public interface IAPIMovieProvider
    {
        //Task<MovieResult> GetMoviesList(string url);
        List<string> GetMovieList(string url);
    }
}
