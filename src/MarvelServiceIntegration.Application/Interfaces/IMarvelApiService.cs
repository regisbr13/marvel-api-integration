using MarvelServiceIntegration.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarvelServiceIntegration.Application.Interfaces
{
    public interface IMarvelApiService
    {
        Task<List<ComicBook>> GetComicsByCharacter(int characterId, int limitResults);
    }
}