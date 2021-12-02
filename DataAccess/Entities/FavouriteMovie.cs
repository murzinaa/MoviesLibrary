namespace MoviesLibrary.DataAccess.Entities
{
    public class FavouriteMovie
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual User User { get; set; }
    }
}
