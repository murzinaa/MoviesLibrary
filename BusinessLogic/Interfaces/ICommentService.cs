using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces
{
    public interface ICommentService
    {
        void AddComment(Comment comment);
        Task<List <Comment>> GetCommentsByMovieTitle(string title);
    }
}
