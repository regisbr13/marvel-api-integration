using Xunit;

namespace MarvelApiIntegration.Api.Tests.Helpers
{
    [CollectionDefinition(nameof(ApiTestsFixtureCollection))]
    public class ApiTestsFixtureCollection : ICollectionFixture<ApiTestsFixture>
    {
    }
}