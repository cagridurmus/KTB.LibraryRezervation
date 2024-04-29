using KTB.LibraryRezervation.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KTB.LibraryRezervation.Repositories.Seeds
{
    public class SeatSeed : IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            builder.HasData(
            new Seat
            {
                Id = 1,
                CreatedAt = DateTime.Now,
                Name = "1A",
                DeskId = 1
            },
            new Seat
            {
                Id = 2,
                CreatedAt = DateTime.Now,
                Name = "1B",
                DeskId = 1
            },
            new Seat
            {
                Id = 3,
                CreatedAt = DateTime.Now,
                Name = "2A",
                DeskId = 2
            },
            new Seat
            {
                Id = 4,
                CreatedAt = DateTime.Now,
                Name = "2B",
                DeskId = 2
            },
            new Seat
            {
                Id = 5,
                CreatedAt = DateTime.Now,
                Name = "3A",
                DeskId = 3
            },
            new Seat
            {
                Id = 6,
                CreatedAt = DateTime.Now,
                Name = "3B",
                DeskId = 3
            },
            new Seat
            {
                Id = 7,
                CreatedAt = DateTime.Now,
                Name = "4A",
                DeskId = 4
            },
            new Seat
            {
                Id = 8,
                CreatedAt = DateTime.Now,
                Name = "4B",
                DeskId = 4
            },
            new Seat
            {
                Id = 9,
                CreatedAt = DateTime.Now,
                Name = "5A",
                DeskId = 5
            },
            new Seat
            {
                Id = 10,
                CreatedAt = DateTime.Now,
                Name = "5B",
                DeskId = 5
            },
            new Seat
            {
                Id = 11,
                CreatedAt = DateTime.Now,
                Name = "6A",
                DeskId = 6
            },
            new Seat
            {
                Id = 12,
                CreatedAt = DateTime.Now,
                Name = "6B",
                DeskId = 6
            },
            new Seat
            {
                Id = 13,
                CreatedAt = DateTime.Now,
                Name = "7A",
                DeskId = 7
            },
            new Seat
            {
                Id = 14,
                CreatedAt = DateTime.Now,
                Name = "7B",
                DeskId = 7
            },
            new Seat
            {
                Id = 15,
                CreatedAt = DateTime.Now,
                Name = "8A",
                DeskId = 8
            },
            new Seat
            {
                Id = 16,
                CreatedAt = DateTime.Now,
                Name = "8B",
                DeskId = 8
            },
            new Seat
            {
                Id = 17,
                CreatedAt = DateTime.Now,
                Name = "1A",
                DeskId = 9
            },
            new Seat
            {
                Id = 18,
                CreatedAt = DateTime.Now,
                Name = "1B",
                DeskId = 9
            },
            new Seat
            {
                Id = 19,
                CreatedAt = DateTime.Now,
                Name = "2A",
                DeskId = 10
            },
            new Seat
            {
                Id = 20,
                CreatedAt = DateTime.Now,
                Name = "2B",
                DeskId = 10
            },
            new Seat
            {
                Id = 21,
                CreatedAt = DateTime.Now,
                Name = "3A",
                DeskId = 11
            },
            new Seat
            {
                Id = 22,
                CreatedAt = DateTime.Now,
                Name = "3B",
                DeskId = 11
            },
            new Seat
            {
                Id = 23,
                CreatedAt = DateTime.Now,
                Name = "4A",
                DeskId = 12
            },
            new Seat
            {
                Id = 24,
                CreatedAt = DateTime.Now,
                Name = "4B",
                DeskId = 12
            },
            new Seat
            {
                Id = 25,
                CreatedAt = DateTime.Now,
                Name = "5A",
                DeskId = 13
            },
            new Seat
            {
                Id = 26,
                CreatedAt = DateTime.Now,
                Name = "5B",
                DeskId = 13
            }
            );
        }
    }
}

