using Ytsoob.Api;
using Ytsoob.Shared.Data;
using Ytsoob.TestsShared.Fixtures;
using Ytsoob.TestsShared.TestBase;
using Xunit.Abstractions;

namespace Ytsoob.IntegrationTests;

[Collection(IntegrationTestYtsoobCollection.Name)]
public class YtsoobIntegrationTestBase : IntegrationTestBase<YtsoobApiMetadata, YtsoobDbContext>
{
    public YtsoobIntegrationTestBase(
        SharedFixtureWithEfCore<YtsoobApiMetadata, YtsoobDbContext> sharedFixture,
        ITestOutputHelper outputHelper
    )
        : base(sharedFixture, outputHelper)
    {
    }
}
