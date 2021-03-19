using MarvelServiceIntegration.Application.Dtos;
using MarvelServiceIntegration.Application.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MarvelServiceIntegration.Application.Services
{
    public class MarvelApiService : IMarvelApiService
    {
        private readonly HttpClient _httpClient;
        private readonly MarvelComicsApiSettings _settings;

        public MarvelApiService(HttpClient httpClient, MarvelComicsApiSettings settings)
        {
            _httpClient = httpClient;
            _settings = settings;
        }

        public async Task<List<ComicBook>> GetComicsByCharacter(int characterId, int limitResults)
        {
            var response = await _httpClient.GetAsync($"comics?{_settings.GetValidPathPrefix()}&characters={characterId}&limit={limitResults}");
            if (!response.IsSuccessStatusCode) return null;

            var content = await DeserializeObjectResponse<ApiResponse>(response);
            return content.Data.ComicBooks;
        }

        private async Task<T> DeserializeObjectResponse<T>(HttpResponseMessage response)
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            return JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync(), options);
        }
    }
}