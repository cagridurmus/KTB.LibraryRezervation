using System;
namespace KTB.LibraryRezervation.Core.Models
{
	public class WorkingHour : BaseEntity
    {
		public DayOfWeek Day { get; set; }

		public DateTime OpeningTime { get; set; }

		public DateTime ClosingTime { get; set; }
	}
}

