using System.Threading.Tasks;

namespace MarvelServiceIntegration.Application.Interfaces
{
    public interface IComicsService
    {
        Task<string> GetCharacterCsvFile(int characterId, int limitResults);
    }
}