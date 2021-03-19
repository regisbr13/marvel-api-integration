using FluentAssertions;
using MarvelApiIntegration.Application.Extensions;
using MarvelApiIntegration.Application.Tests.Helpers;
using Xunit;

namespace MarvelApiIntegration.Application.Tests
{
    [Collection(nameof(ApplicationTestsFixtureCollection))]
    public class StringExtensionsTests
    {
        private readonly ApplicationTestsFixture _fixture;

        public StringExtensionsTests(ApplicationTestsFixture fixture) => _fixture = fixture;

        [Fact]
        public void ReceiveAString_ShouldReturnAStringWithoutAnyBreakLines()
        {
            // Arrange
            var stringWithLines = _fixture.GetStringWithBreakLines();

            // Act
            var result = stringWithLines.RemoveAllBreakLines();

            // Assert
            result.Should().NotContain("\n");
            result.Should().NotContain("\r");
            result.Should().NotContain("\r\n");
        }
    }
}