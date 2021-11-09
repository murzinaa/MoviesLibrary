﻿using MoviesLibrary.Models;
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
        List<string> GetMovieListById(string url);
        List<string> GetFavouriteMoviesList(string url);
    }
}
