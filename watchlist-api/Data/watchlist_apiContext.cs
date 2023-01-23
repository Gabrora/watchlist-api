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
            modelBuilder.Entity<Content>() 
                .Property(b => b.Rating)
                .HasPrecision(3, 1);

        }


    }
}
