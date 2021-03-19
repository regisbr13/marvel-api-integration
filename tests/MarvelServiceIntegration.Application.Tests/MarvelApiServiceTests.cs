using FluentAssertions;
using MarvelServiceIntegration.Application.Tests.Helpers;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace MarvelServiceIntegration.Application.Tests
{
    [Collection(nameof(ApplicationTestsFixtureCollection))]
    public class MarvelApiServiceTests
    {
        private readonly ApplicationTestsFixture _fixture;

        public MarvelApiServiceTests(ApplicationTestsFixture fixture) => _fixture = fixture;

        [Fact]
        public async Task ReceiveACharacterIdAndLimitResults_ShouldReturnAListOfComicBooksFromCharacter()
        {
            // Arrange
            var comics = _fixture.GetComics();
            var reponseMessage = _fixture.GetSuccessfulResponse(_fixture.MarvelApiResponseContent(comics));
            var httpClient = _fixture.GetHttpClient(reponseMessage);
            var sut = _fixture.GetMarvelApiService(httpClient);

            // Act
            var result = await sut.GetComicsByCharacter(It.IsAny<int>(), It.IsAny<int>());

            // Assert
            result.Should().BeEquivalentTo(comics);
        }

        [Fact]
        public async Task ReceiveAnInvalidCharacterIdAndLimitResults_ShouldReturnANull()
        {
            // Arrange
            var reponseMessage = _fixture.GetUnsuccessfulResponse();
            var httpClient = _fixture.GetHttpClient(reponseMessage);
            var sut = _fixture.GetMarvelApiService(httpClient);

            // Act
            var result = await sut.GetComicsByCharacter(It.IsAny<int>(), It.IsAny<int>());

            // Assert
            result.Should().BeNull();
        }
    }
}