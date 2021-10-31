using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataAccess.Entities
{
    public class FavouriteMovie
    {
        [Key]
        public int MovieId{ get; set; }
        public int UserId { get; set; }
        
    }
}
