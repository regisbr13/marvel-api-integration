using Xunit;

namespace MarvelServiceIntegration.Application.Tests.Helpers
{
    [CollectionDefinition(nameof(ApplicationTestsFixtureCollection))]
    public class ApplicationTestsFixtureCollection : ICollectionFixture<ApplicationTestsFixture>
    {
    }
}