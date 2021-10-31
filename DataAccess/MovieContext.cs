using DataAccess;
using DataAccess.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;


namespace DataAccess
{
    public class MovieContext : IdentityDbContext<UserRegistration>
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
            modelBuilder.Entity<User>()
            .HasMany(u => u.Comments)
            .WithOne(c => c.User);
            modelBuilder.Entity<Comment>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<FavouriteMovie>()
                .HasKey(f => f.MovieId);

        }
                
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(("Server=(localdb)\\mssqllocaldb;Database=MoviesLibrary;Trusted_Connection=True;MultipleActiveResultSets=true", b => b.MigrationsAssembly("DataAccess"));
        //}
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

