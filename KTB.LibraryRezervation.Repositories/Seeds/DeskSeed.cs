using System;
using KTB.LibraryRezervation.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KTB.LibraryRezervation.Repositories.Seeds
{
	public class DeskSeed : IEntityTypeConfiguration<Desk>
    {
        public void Configure(EntityTypeBuilder<Desk> builder)
        {
            builder.HasData(
            new Desk
            {
                Id = 1,
                CreatedAt = DateTime.Now,
                DeskNo = 1,
                Capacity = 2,
                LibraryHallId = 1
            },
            new Desk
            {
                Id = 2,
                CreatedAt = DateTime.Now,
                DeskNo = 2,
                Capacity = 2,
                LibraryHallId = 1
            },
            new Desk
            {
                Id = 3,
                CreatedAt = DateTime.Now,
                DeskNo = 3,
                Capacity = 2,
                LibraryHallId = 1
            },
            new Desk
            {
                Id = 4,
                CreatedAt = DateTime.Now,
                DeskNo = 4,
                Capacity = 2,
                LibraryHallId = 1
            },
            new Desk
            {
                Id = 5,
                CreatedAt = DateTime.Now,
                DeskNo = 5,
                Capacity = 2,
                LibraryHallId = 1
            },
            new Desk
            {
                Id = 6,
                CreatedAt = DateTime.Now,
                DeskNo = 6,
                Capacity = 2,
                LibraryHallId = 1
            },
            new Desk
            {
                Id = 7,
                CreatedAt = DateTime.Now,
                DeskNo = 7,
                Capacity = 2,
                LibraryHallId = 1
            },
            new Desk
            {
                Id = 8,
                CreatedAt = DateTime.Now,
                DeskNo = 8,
                Capacity = 2,
                LibraryHallId = 1
            },
            new Desk
            {
                Id = 9,
                CreatedAt = DateTime.Now,
                DeskNo = 1,
                Capacity = 2,
                LibraryHallId = 2
            },
            new Desk
            {
                Id = 10,
                CreatedAt = DateTime.Now,
                DeskNo = 2,
                Capacity = 2,
                LibraryHallId = 2
            },
            new Desk
            {
                Id = 11,
                CreatedAt = DateTime.Now,
                DeskNo = 3,
                Capacity = 2,
                LibraryHallId = 2
            },
            new Desk
            {
                Id = 12,
                CreatedAt = DateTime.Now,
                DeskNo = 4,
                Capacity = 2,
                LibraryHallId = 2
            },
            new Desk
            {
                Id = 13,
                CreatedAt = DateTime.Now,
                DeskNo = 5,
                Capacity = 2,
                LibraryHallId = 2
            }
            );
        }
    }
}

