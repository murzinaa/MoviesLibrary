using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using MoviesLibrary.BusinessLogic.Interfaces;
using MoviesLibrary.DataAccess.Entities;
using MoviesLibrary.DataAccess;

namespace MoviesLibrary.BusinessLogic.Services
{
    public class CommentService : ICommentService
    {
        private readonly MovieContext _context;
        public CommentService(MovieContext context)
        {
            _context = context;

        }

        public void AddComment(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public async Task<List<Comment>> GetCommentsByMovieTitle(string title)
        {
            var result = from c in _context.Comments
                         select c;
            result = result.Where(c => c.MovieTitle!.Contains(title));
            return await result.ToListAsync();
        }

        public List<Comment> GetCommentsByUserId(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
