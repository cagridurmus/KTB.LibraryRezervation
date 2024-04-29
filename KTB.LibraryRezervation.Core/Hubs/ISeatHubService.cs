
using System;
namespace KTB.LibraryRezervation.Core.Hubs
{
	public interface ISeatHubService
    {
        Task SeatRezervMessageAsync(int hallId, int seatId, string message);
    }
}

