
using KTB.LibraryRezervation.Core.Models;

namespace KTB.LibraryRezervation.Core.Repositories
{
	public interface IReservationRepository: IGenericRepository<Reservation>
    {
		Task<List<Reservation>> GetActiveRezervationAsync(AppUser user);

		Task<List<Reservation>> GetPastRezervationAsync(AppUser user);

        Task<bool> HasLastWeekReservation(AppUser user, DateTime reservationStartTime);

    }
}

