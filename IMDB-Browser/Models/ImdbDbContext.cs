using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace IMDB_Browser.Models
{
    public class ImdbDbContext : DbContext
    {
        public ImdbDbContext(DbContextOptions<ImdbDbContext> options) : base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
      //      optionsBuilder.UseSqlServer(@"Server=.;Database=DemoDb122;Trusted_Connection=True;Integrated Security=true;Encrypt=false;")
		    //.LogTo(Console.WriteLine, LogLevel.Information)
      //      .EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasOne(e => e.Rating)
                .WithOne(e => e.Movie)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Rating>()
                .HasOne(e => e.Movie)
                .WithOne(e => e.Rating)
                .OnDelete(DeleteBehavior.NoAction);
            base.OnModelCreating(modelBuilder);
        }
    }
}
