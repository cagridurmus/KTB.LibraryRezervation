using System;
namespace KTB.LibraryRezervation.Core.Models
{
	public class Reservation: BaseEntity
	{
		public AppUser? AppUser { get; set; }

		public int SeatId { get; set; }

		public Seat? Seat { get; set; }

		public DateTime StartTime { get; set; }

		public DateTime EndTime { get; set; }
	}
}

