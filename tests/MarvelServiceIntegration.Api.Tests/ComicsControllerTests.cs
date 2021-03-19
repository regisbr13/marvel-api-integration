using FluentAssertions;
using MarvelServiceIntegration.Api.Tests.Helpers;
using MarvelServiceIntegration.Application.Interfaces;
using MarvelServiceIntegration.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MarvelServiceIntegration.Api.Tests
{
    [Collection(nameof(ApiTestsFixtureCollection))]
    public class ComicsControllerTests
    {
        private readonly ApiTestsFixture _fixture;

        public ComicsControllerTests(ApiTestsFixture fixture) => _fixture = fixture;

        [Fact]
        public async Task ReceiveACharacterIdAndLimitResults_ShouldReturnACsvFile()
        {
            // Arrange
            var sut = _fixture.AutoMocker.CreateInstance<ComicsController>();
            var csvContent = _fixture.Faker.Random.String2(15);
            var defaultCharacterId = "1009718";
            var comicsService = _fixture.AutoMocker.GetMock<IComicsService>();
            comicsService.Setup(s => s.GetCharacterCsvFile(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(csvContent);

            // Act
            var result = await sut.Get() as FileContentResult;

            // Assert
            result.ContentType.Should().Be("text/csv");
            result.FileContents.Should().BeEquivalentTo(Encoding.ASCII.GetBytes(csvContent));
            result.FileDownloadName.Should().Contain(defaultCharacterId);
        }
    }
}