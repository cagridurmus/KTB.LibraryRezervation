using KTB.LibraryRezervation.Core.DTOs;
using KTB.LibraryRezervation.Core.DTOs.Desk;

namespace KTB.LibraryRezervation.Web.Services
{
    public class DeskApiService: BaseApiService
	{
        public DeskApiService(HttpClient httpClient, IConfiguration configuration) : base(httpClient, configuration)
        {
        }

        public async Task<List<GetDeskDto>> GetDeskWithHallIdAsync(int hallId, DateTime startTime, DateTime endTime)
        {
            var url = $"{BaseUrl}/api/desk?hallId={hallId}&startTime={startTime}&endTime={endTime}";
            var response = await HttpClient.GetFromJsonAsync<CustomResponseDto<List<GetDeskDto>>>(url);
            return response.Data;
        }
    }
}

