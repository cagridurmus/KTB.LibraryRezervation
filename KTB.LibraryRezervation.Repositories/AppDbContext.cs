using System;
using System.Reflection;
using KTB.LibraryRezervation.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KTB.LibraryRezervation.Repositories
{
	public class AppDbContext: IdentityDbContext<AppUser, AppRole, Guid>
    {
		public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
		{

		}

		public DbSet<Desk> Desks { get; set; }

        public DbSet<LibraryHall> LibraryHalls { get; set; }

		public DbSet<Reservation> Reservations { get; set; }

		public DbSet<WorkingHour> WorkingHours { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}

