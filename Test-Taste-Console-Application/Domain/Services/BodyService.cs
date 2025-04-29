using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Test_Taste_Console_Application.Constants;
using Test_Taste_Console_Application.Domain.DataTransferObjects;
using Test_Taste_Console_Application.Domain.Services.Interfaces;

namespace Test_Taste_Console_Application.Domain.Services
{
    public class BodyService : IBodyService
    {
        private readonly HttpClientService _httpClientService;

        public BodyService(HttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        public async Task<List<BodyDto>> GetBodiesAsync()
        {
            var response = await _httpClientService.Client.GetAsync(UriPath.GetMoonByIdQueryParameters);
            response.EnsureSuccessStatusCode();

            //If the status code isn't 200-299, then the function returns an empty collection.
            if (!response.IsSuccessStatusCode) return null;

            var content = await response.Content.ReadAsStringAsync();

            //The JSON converter uses DTO's, that can be found in the DataTransferObjects folder, to deserialize the response content.
            var apiResponse = JsonSerializer.Deserialize<BodiesResponse>(content);

            return apiResponse.bodies;
        }

        public async Task<BodyDto> GetBodyByIdAsync(string id)
        {
            var response = await _httpClientService.Client.GetAsync(UriPath.GetMoonByIdQueryParameters + id);

            //If the status code isn't 200-299, then the function returns an empty collection.
            if (!response.IsSuccessStatusCode) return null;

            var content = await response.Content.ReadAsStringAsync();

            //The JSON converter uses DTO's, that can be found in the DataTransferObjects folder, to deserialize the response content.
            return JsonSerializer.Deserialize<BodyDto>(content);
        }
    }
}
