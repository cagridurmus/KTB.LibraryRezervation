using KTB.LibraryRezervation.Core.DTOs.Reservation;
using KTB.LibraryRezervation.Core.Models;

namespace KTB.LibraryRezervation.Core.Services
{
    public interface IReservationService: IService<Reservation>
	{
		public Task<bool> CreateReservation(AddReservationDto reservationDto);

        public Task<List<GetReservationDto>> GetUserReservationsAsync(string email);
    }
}

