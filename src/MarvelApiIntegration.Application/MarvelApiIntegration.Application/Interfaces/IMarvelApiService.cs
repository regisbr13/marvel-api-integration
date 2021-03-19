using MarvelApiIntegration.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarvelApiIntegration.Application.Interfaces
{
    public interface IMarvelApiService
    {
        Task<List<ComicBook>> GetComicsByCharacter(int characterId, int limitResults);
    }
}