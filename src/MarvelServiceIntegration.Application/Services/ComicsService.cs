using MarvelServiceIntegration.Application.Extensions;
using MarvelServiceIntegration.Application.Interfaces;
using System.Threading.Tasks;

namespace MarvelServiceIntegration.Application.Services
{
    public class ComicsService : IComicsService
    {
        private readonly IMarvelApiService _service;

        public ComicsService(IMarvelApiService service) => _service = service;

        public async Task<string> GetCharacterCsvFile(int characterId, int limitResults)
        {
            var comics = await _service.GetComicsByCharacter(characterId, limitResults);
            return CsvHelper.GetContent(comics);
        }
    }
}