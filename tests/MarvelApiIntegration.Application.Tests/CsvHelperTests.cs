using FluentAssertions;
using MarvelApiIntegration.Application.Dtos;
using MarvelApiIntegration.Application.Extensions;
using MarvelApiIntegration.Application.Tests.Helpers;
using System.Linq;
using Xunit;

namespace MarvelApiIntegration.Application.Tests
{
    [Collection(nameof(ApplicationTestsFixtureCollection))]
    public class CsvHelperTests
    {
        private readonly ApplicationTestsFixture _fixture;

        public CsvHelperTests(ApplicationTestsFixture fixture) => _fixture = fixture;

        [Fact]
        public void ReceiveAGenericList_ShouldReturnAStringInCsvFormatWithSemicolonDelimiter()
        {
            // Arrange
            var comics = _fixture.GetComics();
            var objProperties = typeof(ComicBook).GetProperties().Select(p => p.Name).ToArray();
            var firstComicsElement = comics.FirstOrDefault();

            // Act
            var result = CsvHelper.GetContent(comics);

            // Assert
            result.Split("\n")[0].Trim().Split(";").Should().Equal(objProperties);
            result.Split("\n")[1].Split(";")[0].Should().Be(firstComicsElement.Id.ToString());
            result.Split("\n")[1].Split(";")[2].Trim().Should().Be(firstComicsElement.Title.RemoveAllBreakLines());
        }
    }
}