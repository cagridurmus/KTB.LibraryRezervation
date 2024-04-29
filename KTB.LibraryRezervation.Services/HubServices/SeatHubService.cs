using KTB.LibraryRezervation.Core.Hubs;
using KTB.LibraryRezervation.Services.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace KTB.LibraryRezervation.Services.HubServices
{
    public class SeatHubService: ISeatHubService
	{
        readonly IHubContext<SeatHub> _hubContext;

        public SeatHubService(IHubContext<SeatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task SeatRezervMessageAsync(int hallId, int seatId, string message)
            => await _hubContext.Clients.All.SendAsync("SeatRezerv", hallId, seatId, message);
    }
}

