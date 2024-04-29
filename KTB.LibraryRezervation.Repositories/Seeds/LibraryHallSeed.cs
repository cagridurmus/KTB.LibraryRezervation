using System;
using KTB.LibraryRezervation.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KTB.LibraryRezervation.Repositories.Seeds
{
	public class LibraryHallSeed: IEntityTypeConfiguration<LibraryHall>
    {
        public void Configure(EntityTypeBuilder<LibraryHall> builder)
        {
            builder.HasData(
            new LibraryHall
            {
                Id = 1,
                CreatedAt = DateTime.Now,
                Name = "Salon 1",
                DeskCapacity = 8,

            },
            new LibraryHall
            {
                Id = 2,
                CreatedAt = DateTime.Now,
                Name = "Salon 2",
                DeskCapacity = 5,
            });
        }
    }
}

