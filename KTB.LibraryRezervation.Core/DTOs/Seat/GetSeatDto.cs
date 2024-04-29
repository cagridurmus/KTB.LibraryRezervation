using KTB.LibraryRezervation.Core.DTOs.Reservation;
using KTB.LibraryRezervation.Core.Models;

namespace KTB.LibraryRezervation.Core.DTOs.Seat
{
    public class GetSeatDto: BaseDto
	{
        public string Name { get; set; }

        public int SeatId { get; set; }

        public bool IsReserved { get; set; }

        public List<GetReservationDto>? Reservations { get; set; } = new List<GetReservationDto>();
    }
}

