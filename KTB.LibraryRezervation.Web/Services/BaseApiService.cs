using System;
namespace KTB.LibraryRezervation.Web.Services
{
	public class BaseApiService
	{
        protected readonly HttpClient HttpClient;
        protected readonly string BaseUrl;

        public BaseApiService(HttpClient httpClient, IConfiguration configuration)
        {
            HttpClient = httpClient;
            BaseUrl = configuration["BaseUrl"];
        }
    }
}

