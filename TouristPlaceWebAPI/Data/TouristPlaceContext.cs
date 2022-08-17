using Microsoft.EntityFrameworkCore;
using System;
using TouristPlaceWebAPI.Models;

namespace TouristPlaceWebAPI.Data
{
    public class TouristPlaceContext : DbContext
    {
        public TouristPlaceContext(DbContextOptions<TouristPlaceContext> options) : base(options)
        {

        }

        public DbSet<ToursitPlaces> ToursitPlaces { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToursitPlaces>()
                .HasIndex(p => p.Name)
                .IsUnique(true);
        }
    }
}
