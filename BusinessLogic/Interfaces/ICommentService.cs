﻿using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Interfaces
{
    public interface ICommentService
    {
        void AddComment(Comment comment);
        List <Comment> GetCommentsByUserId(int userId);
    }
}
