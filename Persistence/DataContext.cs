using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Location> Locations { get; set; }
        public DbSet<City> Cities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<City>()
                .HasData(
                    new City { Id = 1, Name = "Berlin" },
                    new City { Id = 2, Name = "Amsterdam" },
                    new City { Id = 3, Name = "Ljubljana" },
                    new City { Id = 4, Name = "Belgrade" },
                    new City { Id = 5, Name = "Zagreb" },
                    new City { Id = 6, Name = "Sarajevo" },
                    new City { Id = 7, Name = "Prishtina" },
                    new City { Id = 8, Name = "Rome" },
                    new City { Id = 9, Name = "Paris" },
                    new City { Id = 10, Name = "Madrid" },
                    new City { Id = 11, Name = "Istanbul" },
                    new City { Id = 12, Name = "Moscow" },
                    new City { Id = 13, Name = "Stockholm" }
                );

            builder.Entity<Location>()
                .HasOne(c => c.City);

            builder.Entity<City>()
               .HasMany(c => c.Location);
        }
    }
}
