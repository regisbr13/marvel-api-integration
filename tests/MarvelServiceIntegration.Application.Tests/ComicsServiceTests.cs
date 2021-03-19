using FluentAssertions;
using MarvelServiceIntegration.Application.Extensions;
using MarvelServiceIntegration.Application.Interfaces;
using MarvelServiceIntegration.Application.Services;
using MarvelServiceIntegration.Application.Tests.Helpers;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace MarvelServiceIntegration.Application.Tests
{
    [Collection(nameof(ApplicationTestsFixtureCollection))]
    public class ComicsServiceTests
    {
        private readonly ApplicationTestsFixture _fixture;

        public ComicsServiceTests(ApplicationTestsFixture fixture) => _fixture = fixture;

        [Fact]
        public async Task ReceiveACharacterIdAndLimitResults_ShouldReturnAStringInCsvFormatWithSemicolonDelimiter()
        {
            // Arrange
            var sut = _fixture.AutoMocker.CreateInstance<ComicsService>();
            var characterId = 123456;
            var limitResults = 15;
            var comics = _fixture.GetComics();
            var apiService = _fixture.AutoMocker.GetMock<IMarvelApiService>();
            apiService.Setup(s => s.GetComicsByCharacter(characterId, limitResults))
                .ReturnsAsync(comics);

            // Act
            var result = await sut.GetCharacterCsvFile(characterId, limitResults);

            // Assert
            result.Should().Be(CsvHelper.GetContent(comics));
        }
    }
}