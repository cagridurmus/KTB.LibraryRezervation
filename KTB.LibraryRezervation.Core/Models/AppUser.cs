using System;
using Microsoft.AspNetCore.Identity;

namespace KTB.LibraryRezervation.Core.Models
{
	public class AppUser: IdentityUser<Guid>
	{
		public string NameSurname { get; set; }

		public List<Reservation>? Reservations { get; set; } = new List<Reservation>();
	}
}

