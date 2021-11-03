using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interfaces
{
    public interface ICommentService
    {
        public Comment Create(Comment comment);
        public Comment GetByUserId(int userId);
    }
}
