using KTB.LibraryRezervation.Core.DTOs;
using KTB.LibraryRezervation.Core.DTOs.LibraryHall;

namespace KTB.LibraryRezervation.Web.Services
{
    public class LibraryHallApiService : BaseApiService
    {
        public LibraryHallApiService(HttpClient httpClient, IConfiguration configuration) : base(httpClient, configuration)
        {
        }

        public async Task<List<GetLibraryHallDto>> GetAllHallAsync()
        {
            var url = $"{BaseUrl}/api/libraryhall";
            var response = await HttpClient.GetFromJsonAsync<CustomResponseDto<List<GetLibraryHallDto>>>(url);
            return response.Data;
        }
    }
}

