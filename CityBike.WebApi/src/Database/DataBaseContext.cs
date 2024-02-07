using CityBike.Core.src.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Npgsql;

namespace CityBike.WebApi.src.Database
{
    public class DataBaseContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Station> Stations { get; set; }
        public DbSet<Journey> Journeys { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder
            .UseSnakeCaseNamingConvention()
            .ConfigureWarnings(warnings => { warnings.Ignore(CoreEventId.ManyServiceProvidersCreatedWarning); });
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Journey>()
                .HasOne(j => j.DepartureStation)
                .WithMany(s => s.DepartureJourneys)
                .HasForeignKey(j => j.DepartureStationId);

            modelBuilder.Entity<Journey>()
                .HasOne(j => j.ReturnStation)
                .WithMany(s => s.ReturnJourneys)
                .HasForeignKey(j => j.ReturnStationId);
        }

    }

}