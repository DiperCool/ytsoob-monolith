using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Options;
using Sieve.Models;
using Ytsoob.Shared.Core.Paging;
using Ytsoob.TestsShared.XunitCategories;

namespace Ytsoob.UnitTests.Common;

[CollectionDefinition(nameof(QueryTestCollection))]
public class QueryTestCollection : ICollectionFixture<YtsoobUnitTestBase>
{
}

//https://stackoverflow.com/questions/43082094/use-multiple-collectionfixture-on-my-test-class-in-xunit-2-x
// note: each class could have only one collection
[Collection(UnitTestCollection.Name)]
[CategoryTrait(TestCategory.Unit)]
public class YtsoobUnitTestBase : IAsyncDisposable
{
    // We don't need to inject `CustomersServiceMockServersFixture` class fixture in the constructor because it initialized by `collection fixture` and its static properties are accessible in the codes
    public YtsoobUnitTestBase()
    {
        Mapper = MapperFactory.Create();
        IOptions<SieveOptions> options = Options.Create(new SieveOptions { DefaultPageSize = 10, MaxPageSize = 10 });
        SieveProcessor = new ApplicationSieveProcessor(options);
    }

    public IMapper Mapper { get; }
    public ApplicationSieveProcessor SieveProcessor { get; }

    public IValidator<T> GetFakeValidator<T>()
        where T : class
    {
        return new FakeValidator<T>();
    }

    public async ValueTask DisposeAsync()
    {
    }
}
