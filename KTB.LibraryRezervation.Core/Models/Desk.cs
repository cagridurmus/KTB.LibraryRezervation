namespace KTB.LibraryRezervation.Core.Models
{
    public class Desk: BaseEntity
    {
		public int LibraryHallId { get; set; }

        public LibraryHall? LibraryHall { get; set; }

		public int DeskNo { get; set; }

		public List<Seat>? Seats { get; set; } = new List<Seat>();

		public int Capacity { get; set; }
	}
}


