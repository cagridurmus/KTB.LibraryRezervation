using System;
using KTB.LibraryRezervation.Core.DTOs;
using KTB.LibraryRezervation.Core.DTOs.Login;

namespace KTB.LibraryRezervation.Web.Services
{
	public class AuthApiService: BaseApiService
	{
        public AuthApiService(HttpClient httpClient, IConfiguration configuration) : base(httpClient, configuration)
        {
        }

        public async Task<bool> LoginAsync(LoginUserDto user)
        {
            var url = $"{BaseUrl}/api/auth";
            var response = await HttpClient.PostAsJsonAsync(url, user);
            if (!response.IsSuccessStatusCode) return false;
            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<bool>>();

            return responseBody.Data;
        }
    }
}

