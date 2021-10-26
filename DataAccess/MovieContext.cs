using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;


namespace DataAccess
{
    public class MovieContext : DbContext
    {
        public DbSet<FavouriteMovie> FavouriteMovie { get; set; }
        public DbSet<Comment> Comment { get; set; }
        //public DbSet<Movie> Movie{ get; set; }
        public DbSet<User> User { get; set; }

        //public DbSet<Entities.Action> Action { get; set; }

        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
    public class MovieContextFactory : IDesignTimeDbContextFactory<MovieContext>
    {
        public MovieContext CreateDbContext(string[] args)
        {
            var OptionsBuilder = new DbContextOptionsBuilder<MovieContext>();
            OptionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MoviesLibrary;Trusted_Connection=True;MultipleActiveResultSets=true", b => b.MigrationsAssembly("DataAccess"));
            return new MovieContext(OptionsBuilder.Options);
        }
    }
}
