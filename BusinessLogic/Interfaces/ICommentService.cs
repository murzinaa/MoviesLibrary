﻿using MoviesLibrary.DataAccess.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MoviesLibrary.BusinessLogic.Interfaces
{
    public interface ICommentService
    {
        void AddComment(Comment comment);
        Task<List<Comment>> GetCommentsByMovieTitle(string title);
    }
}
