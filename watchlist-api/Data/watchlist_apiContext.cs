using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using watchlist_api.Models;

namespace watchlist_api.Data
{
    public class watchlist_apiContext : DbContext
    {
        public watchlist_apiContext (DbContextOptions<watchlist_apiContext> options)
            : base(options)
        {
        }

        public DbSet<WatchList> WatchList { get; set; } = default!;
        public DbSet<Content> Content { get; set; } = default!;
        public DbSet<User> User { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Content>() //ratings should start from 0.0 and end at 10.0
                .Property(b => b.Rating)
                .HasPrecision(3, 1);

            modelBuilder.Entity<Content>() // realease date only should have Year month and day
                .Property(b => b.ReleaseDate)
                .HasConversion(
                v => v.Date,
                v => new DateTime(v.Year, v.Month, v.Day)
                );
        }
    }
}
