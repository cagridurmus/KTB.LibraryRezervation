using KTB.LibraryRezervation.Core.DTOs;
using KTB.LibraryRezervation.Core.DTOs.Register;

namespace KTB.LibraryRezervation.Web.Services
{
    public class UserApiService: BaseApiService
	{
        public UserApiService(HttpClient httpClient, IConfiguration configuration) : base(httpClient, configuration)
        {
        }

        public async Task<bool> CreateUserAsync(RegisterUserDto newUser)
        {
            var url = $"{BaseUrl}/api/user";
            var response = await HttpClient.PostAsJsonAsync(url, newUser);
            if (!response.IsSuccessStatusCode) return false;
            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<bool>>();

            return responseBody.Data;
        }
    }
}

