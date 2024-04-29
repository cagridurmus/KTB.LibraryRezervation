using System;
using KTB.LibraryRezervation.Core.DTOs.Desk;
using KTB.LibraryRezervation.Core.Models;

namespace KTB.LibraryRezervation.Core.Services
{
	public interface IDeskService: IService<Desk>
	{
		public Task<List<GetDeskDto>> GetDesksWithSeatAsync(int hallId, DateTime startTime, DateTime endTime);
	}
}

