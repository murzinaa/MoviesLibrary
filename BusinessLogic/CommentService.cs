using BusinessLogic.Interfaces;
using DataAccess;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public class CommentService  //ICommentService
    {
        private readonly MovieContext context;
        public CommentService(MovieContext context)
        {
            this.context = context;
      
        }
        public Comment Create(Comment comment)
        {
            var result = context.Add(comment);
            context.SaveChanges();
            return result.Entity;
        }

        public Comment GetByUserId(int userId)
        {
            //throw new NotImplementedException();
            return context.Set<Comment>().Find(userId);
        }
    }
}
