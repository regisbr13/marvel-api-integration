using MarvelApiIntegration.Application.Extensions;
using MarvelApiIntegration.Application.Interfaces;
using System.Threading.Tasks;

namespace MarvelApiIntegration.Application.Services
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