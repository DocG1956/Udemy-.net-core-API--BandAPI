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
                    Id = Guid.Parse("f03d119b-04b4-4c17-9a5f-a5afbdf0a3b8"),
                    Name = "Metallica",
                    Founded = new DateTime(1980, 1, 1),
                    MainGenre = "Heavy Metal"
                },
                new Band()
                {
                    Id = Guid.Parse("fa6f8bb2c-b1d9-4e9e-8963-45a5ec726530"),
                    Name = "Guns N Roses",
                    Founded = new DateTime(1985, 2, 1),
                    MainGenre = "Rock"
                },
                new Band()
                {
                    Id = Guid.Parse("cd411bd8-dfb2-4c8f-a40a-20a8aa75cae4"),
                    Name = "ABBA",
                    Founded = new DateTime(1965, 3, 1),
                    MainGenre = "Desco"
                },
                new Band()
                {
                    Id = Guid.Parse("fa5080395-cf13-43dd-8484-4449a5259e6b"),
                    Name = "Oasis",
                    Founded = new DateTime(1991, 12, 1),
                    MainGenre = "Heavy Metal"

                });

            modelBuilder.Entity<Album>().HasData(
                new Album()
                {
                    Id = Guid.Parse("62cc9e41-6d2a-4a08-97fd-693a424f346e"),
                    Title = "Master of Puppets",
                    Description = "One of the best ever",
                    BandId = Guid.Parse("f03d119b-04b4-4c17-9a5f-a5afbdf0a3b8"),
                },
                new Album()
                {
                    Id = Guid.Parse("2e04d996-c2f6-4e98-ba36-2b7a1d619e0b"),
                    Title = "GunsNRoses Album",
                    Description = "One of the best ever",
                    BandId = Guid.Parse("fa6f8bb2c-b1d9-4e9e-8963-45a5ec726530"),
                },
                new Album()
                {
                    Id = Guid.Parse("4e04f9d4-001a-4f94-955a-63375f9494bd"),
                    Title = "Abba Album",
                    Description = "One of the best ever",
                    BandId = Guid.Parse("cd411bd8-dfb2-4c8f-a40a-20a8aa75cae4"),
                },
                new Album()
                {
                    Id = Guid.Parse("8d9c939c-800b-45b6-a197-9bd907e5a495"),
                    Title = "Oasis Album",
                    Description = "One of the best ever",
                    BandId = Guid.Parse("fa5080395-cf13-43dd-8484-4449a5259e6b"),
                });

            base.OnModelCreating(modelBuilder);
        }


    }
}
