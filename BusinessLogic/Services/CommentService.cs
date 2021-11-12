using BusinessLogic.Interfaces;
using DataAccess;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Services
{
    public class CommentService: ICommentService
    {
        private readonly MovieContext context;
        public CommentService(MovieContext context)
        {
            this.context = context;
      
        }

        public void AddComment(Comment comment)
        {
            context.Comments.Add(comment);
            context.SaveChanges();
        }


        public List<Comment> GetCommentsByUserId(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
