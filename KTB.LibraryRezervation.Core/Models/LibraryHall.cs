namespace KTB.LibraryRezervation.Core.Models
{
    public class LibraryHall: BaseEntity
	{
		public string Name { get; set; }

		public int DeskCapacity { get; set; }

		public List<Desk>? Desks { get; set; } = new List<Desk>();
	}
}

