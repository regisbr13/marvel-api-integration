using System.Threading.Tasks;

namespace MarvelApiIntegration.Application.Interfaces
{
    public interface IComicsService
    {
        Task<string> GetCharacterCsvFile(int characterId, int limitResults);
    }
}