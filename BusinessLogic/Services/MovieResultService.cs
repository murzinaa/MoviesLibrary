using MoviesLibrary.APIProviders;
using MoviesLibrary.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static MoviesLibrary.BusinessLogic.Utils.Constants;

namespace MoviesLibrary.BusinessLogic.Services
{
    public class MovieResultService: IMovieResultService
    {
        private readonly ICommentService _commentService;
        private readonly IApiMovieProvider _apiMovieProvider;
        public MovieResultService(ICommentService commentService, IApiMovieProvider apiMovieProvider)
        {
            _commentService = commentService;
            _apiMovieProvider = apiMovieProvider;
        }

        public void ReturnMovieResult(string movie)
        {
            throw new NotImplementedException();
        }
    }
}
