using System.Net.Http.Json;
using KTB.LibraryRezervation.Core.DTOs;
using KTB.LibraryRezervation.Core.DTOs.Reservation;

namespace KTB.LibraryRezervation.Web.Services
{
    public class ReservationApiService: BaseApiService
	{
        public ReservationApiService(HttpClient httpClient, IConfiguration configuration) : base(httpClient, configuration)
        {
        }

        public async Task<string> AddReservationAsync(AddReservationDto reservation)
        {
            var url = $"{BaseUrl}/api/reservation";
            var response = await HttpClient.PostAsJsonAsync(url, reservation);
            
            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<string>>();
            if (!response.IsSuccessStatusCode) return responseBody.Errors.First();

            return "Başarıyla rezervasyonunuz eklendi";
        }

        public async Task<List<GetReservationDto>> GetReservationAsync(string email)
        {
            var url = $"{BaseUrl}/api/reservation/{email}";
            var response = await HttpClient.GetFromJsonAsync<CustomResponseDto<List<GetReservationDto>>>(url);

            return response.Data;
        }
    }
}

