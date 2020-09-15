using BandAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace BandAPI.DbContexts
{
    public class BandAlbumContext : DbContext
    {
        public BandAlbumContext(DbContextOptions<BandAlbumContext> options) : base(options)
        {
        }

        public DbSet<Band> Bands { get; set; }
        public DbSet<Album> Albums { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Band>().HasData(
            new Band()
            {
                Id = Guid.Parse("1548d4d6-f6af-11ea-adc1-0242ac120002"),
                Name = "Metallica",
                Founded = new DateTime(1980, 1, 1),
                MainGenre = "Heavy Metal"
            },
            new Band()
            {
                Id = Guid.Parse("1548d71a-f6af-11ea-adc1-0242ac120002"),
                Name = "Guns N Roses",
                Founded = new DateTime(1985, 2, 1),
                MainGenre = "Rock"
            },
            new Band()
            {
                Id = Guid.Parse("1548d81e-f6af-11ea-adc1-0242ac120002"),
                Name = "ABBA",
                Founded = new DateTime(1965, 3, 1),
                MainGenre = "Desco"
            },
            new Band()
            {
                Id = Guid.Parse("1548d8f0-f6af-11ea-adc1-0242ac120002"),
                Name = "Oasis",
                Founded = new DateTime(1991, 12, 1),
                MainGenre = "Heavy Metal"
            });

            modelBuilder.Entity<Album>().HasData(
            new Album()
            {
                Id = Guid.Parse("aa1700a6-f6af-11ea-adc1-0242ac120002"),
                Title = "Master of Puppets",
                Description = "One of the best ever",
                BandId = Guid.Parse("1548d4d6-f6af-11ea-adc1-0242ac120002"),
            },
            new Album()
            {
                Id = Guid.Parse("aa17043e-f6af-11ea-adc1-0242ac120002"),
                Title = "GunsNRoses Album",
                Description = "One of the best ever",
                BandId = Guid.Parse("1548d71a-f6af-11ea-adc1-0242ac120002"),
            },
            new Album()
            {
                Id = Guid.Parse("aa170736-f6af-11ea-adc1-0242ac120002"),
                Title = "Abba Album",
                Description = "One of the best ever",
                BandId = Guid.Parse("1548d81e-f6af-11ea-adc1-0242ac120002"),
            },
            new Album()
            {
                Id = Guid.Parse("aa170844-f6af-11ea-adc1-0242ac120002"),
                Title = "Oasis Album",
                Description = "One of the best ever",
                BandId = Guid.Parse("1548d8f0-f6af-11ea-adc1-0242ac120002"),
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
