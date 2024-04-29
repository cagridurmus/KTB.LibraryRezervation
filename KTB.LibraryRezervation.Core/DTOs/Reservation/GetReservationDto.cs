using KTB.LibraryRezervation.Core.Models;

namespace KTB.LibraryRezervation.Core.DTOs.Reservation
{
    public class GetReservationDto : BaseDto
	{

        public int SeatId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public bool isActive { get; set; }
    }
}

