using System;
using KTB.LibraryRezervation.Core.Models;
using KTB.LibraryRezervation.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace KTB.LibraryRezervation.Repositories.Repositories
{
    public class ReservationRepository : GenericRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Reservation>> GetActiveRezervationAsync(AppUser user)
        {
            var now = DateTime.Now;
            var rezervations = await Where(rzv => rzv.AppUser == user && rzv.StartTime <= now && rzv.EndTime >= now)
                    .ToListAsync();
            return rezervations;
        }

        public async Task<List<Reservation>> GetPastRezervationAsync(AppUser user)
        {
            var rezervations = await Where(rzv => rzv.AppUser == user && rzv.StartTime > DateTime.Now)
                    .ToListAsync();
            return rezervations;
        }

        //public async Task<List<Reservation>> GetUserReservationsAsync(AppUser user)
        //{
        //    var rezervations = await Where(rzv => rzv.AppUser == user)
        //            .ToListAsync();
        //    return rezervations;
        //}

        public async Task<bool> HasLastWeekReservation(AppUser user, DateTime reservationStartTime)
        {
            var lastWeekDate = reservationStartTime.AddDays(-7);
            var rezervations = await Where(rzv => rzv.AppUser == user && rzv.StartTime <= reservationStartTime && rzv.EndTime >= lastWeekDate).CountAsync() >= 2;
            
            return rezervations;
        }
    }
}

