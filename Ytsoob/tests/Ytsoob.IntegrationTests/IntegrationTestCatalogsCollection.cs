using Ytsoob.Api;
using Ytsoob.Shared.Data;
using Ytsoob.TestsShared.Fixtures;

namespace Ytsoob.IntegrationTests;

[CollectionDefinition(Name)]
public class IntegrationTestYtsoobCollection
    : ICollectionFixture<SharedFixtureWithEfCore<YtsoobApiMetadata, YtsoobDbContext>>
{
    public const string Name = "Ytsoob Integration Test";
}

[CollectionDefinition(Name)]
public class IntegrationTestUsersCollection : ICollectionFixture<SharedFixture<YtsoobApiMetadata>>
{
    public const string Name = "Users Integration Test";
}
