using Xunit;

namespace MarvelApiIntegration.Application.Tests.Helpers
{
    [CollectionDefinition(nameof(ApplicationTestsFixtureCollection))]
    public class ApplicationTestsFixtureCollection : ICollectionFixture<ApplicationTestsFixture>
    {
    }
}