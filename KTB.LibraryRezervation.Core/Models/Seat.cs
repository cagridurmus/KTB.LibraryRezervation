using System;
namespace KTB.LibraryRezervation.Core.Models
{
	public class Seat: BaseEntity
	{
		public string Name { get; set; }

		public int DeskId { get; set; }

		public Desk? Desk { get; set; }

        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}

