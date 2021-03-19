using MarvelServiceIntegration.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using System.Threading.Tasks;

namespace MarvelServiceIntegration.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComicsController : ControllerBase
    {
        private readonly IComicsService _service;

        public ComicsController(IComicsService service) => _service = service;

        [HttpGet("{characterId:int}")]
        [Produces("text/csv")]
        [ProducesResponseType(typeof(FileContentResult), StatusCodes.Status200OK)]
        public async Task<ActionResult> Get(int characterId = 1009718, int limitResults = 15)
        {
            var csvContent = await _service.GetCharacterCsvFile(characterId, limitResults);
            return File(Encoding.UTF8.GetBytes(csvContent), "text/csv", $"{characterId}_{DateTime.Now}.csv");
        }
    }
}