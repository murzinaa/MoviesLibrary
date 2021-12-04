using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MoviesLibrary.DataAccess.Entities;


namespace MoviesLibrary.DataAccess
{
    public class MovieContext : IdentityDbContext<User>
    {
        public MovieContext()
        {
        }

        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<FavouriteMovie> FavouriteMovies { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        //public virtual DbSet<User> Users { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //    // optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MoviesLibrary;Trusted_Connection=True;");
        //    //optionsBuilder.UseSqlServer(AppConfiguration.GetConnectionString("DefaultConnection"));
        //    IConfigurationSection connStrings = AppConfiguration.GetSection("ConnectionStrings");
        //    string defaultConnection = connStrings.GetSection("DefaultConnection").Value;
        //}



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Comment>(entity =>
                {
                    entity.ToTable("Comment");

                    entity.HasIndex(e => e.MovieId, "IDX_MOVIE");

                    entity.HasIndex(e => e.UserId, "IDX_USER");

                    entity.Property(e => e.Body)
                        .HasMaxLength(2000)
                        .IsUnicode(false);

                    entity.HasOne(d => d.Movie)
                        .WithMany(p => p.Comments)
                        .HasForeignKey(d => d.MovieId)
                        .HasConstraintName("FK_COMMENT_REFERENCE_MOVIE");

                    entity.HasOne(d => d.User)
                        .WithMany(p => p.Comments)
                        .HasForeignKey(d => d.UserId)
                        .HasConstraintName("FK_COMMENT_REFERENCE_USER");
                });

            modelBuilder.Entity<FavouriteMovie>(entity =>
            {
                //entity.HasNoKey();

                entity.ToTable("FavouriteMovie");

                entity.HasIndex(e => e.MovieId, "IDX_MOVIE1");

                entity.HasIndex(e => e.UserId, "IDX_USER1");

                entity.HasOne(d => d.Movie)
                    .WithMany()
                    .HasForeignKey(d => d.MovieId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FAVOURIT_REFERENCE_MOVIE");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FAVOURIT_REFERENCE_USER");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.ToTable("Movie");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.FullName)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });


        }

    }
}