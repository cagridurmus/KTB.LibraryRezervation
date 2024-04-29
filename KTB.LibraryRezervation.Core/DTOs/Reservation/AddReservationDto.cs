using System;
using KTB.LibraryRezervation.Core.Models;

namespace KTB.LibraryRezervation.Core.DTOs.Reservation
{
	public class AddReservationDto
    {
        public string Email { get; set; }

        public int SeatId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}


