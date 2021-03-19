using Xunit;

namespace MarvelServiceIntegration.Api.Tests.Helpers
{
    [CollectionDefinition(nameof(ApiTestsFixtureCollection))]
    public class ApiTestsFixtureCollection : ICollectionFixture<ApiTestsFixture>
    {
    }
}