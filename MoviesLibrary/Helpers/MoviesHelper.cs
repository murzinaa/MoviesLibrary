using MoviesLibrary.APIProviders;
using MoviesLibrary.BusinessLogic.Interfaces;
using MoviesLibrary.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MoviesLibrary.BusinessLogic.Utils.Constants;

namespace MoviesLibrary.Web.Helpers
{
    public class MoviesHelper
    {
        private readonly ICommentService _commentService;
        private readonly IApiMovieProvider _apiMovieProvider;
        private readonly SettingService _settingService;
        public MoviesHelper(ICommentService commentService, IApiMovieProvider apiMovieProvider, SettingService settingService)
        {
            _commentService = commentService;
            _apiMovieProvider = apiMovieProvider;
            _settingService = settingService;
        }
        public async Task<MovieViewModel> GetMovieViewModel(string movie, string userName, bool inFavourite = false, bool editComment = false, int id = 0)
        {
            var movieViewModel = new MovieViewModel
            {
                MovieComments = (await _commentService.GetCommentsByMovieTitle(movie)).ToList(),
                MovieList = await _apiMovieProvider.GetMoviesListById(FilmApiUrls.ReturnUrlForMovieResult(movie, _settingService.ApiKey)),
                EditComment = editComment,
                IsInFavourite = inFavourite, 
                CommentId = id,
                CurrentUserName = userName
            };
            return movieViewModel;
        }

    }
}
