using KTB.LibraryRezervation.Core.DTOs;
using KTB.LibraryRezervation.Core.DTOs.Desk;
using Microsoft.SqlServer.Server;
using System.Globalization;

namespace KTB.LibraryRezervation.Web.Services
{
    public class DeskApiService: BaseApiService
	{
        public DeskApiService(HttpClient httpClient, IConfiguration configuration) : base(httpClient, configuration)
        {
        }

        public async Task<List<GetDeskDto>> GetDeskWithHallIdAsync(int hallId, DateTime startTime, DateTime endTime)
        {
            var newStartTime = startTime.ToString("ddd, dd MMM yyyy HH:mm:ss 'GMT'", CultureInfo.InvariantCulture);
            var newEndTime = endTime.ToString("ddd, dd MMM yyyy HH:mm:ss 'GMT'", CultureInfo.InvariantCulture);
            var url = $"{BaseUrl}/api/desk?hallId={hallId}&startTime={newStartTime}&endTime={newEndTime}";
            var response = await HttpClient.GetFromJsonAsync<CustomResponseDto<List<GetDeskDto>>>(url);
            return response.Data;
        }
    }
}

