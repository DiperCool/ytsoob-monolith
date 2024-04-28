using System.Reflection;
using Polly;
using Sieve.Services;
using Ytsoob.Shared.Abstractions.Core.Domain.Events;
using Ytsoob.Shared.Abstractions.Ef.Repository;
using Ytsoob.Shared.Core.Domain.Events;
using Ytsoob.Shared.Core.Ef;
using Ytsoob.Shared.Core.Paging;

namespace Ytsoob.Shared.Core.Extensions.ServiceCollectionsExtensions;

public static partial class ServiceCollectionExtensions
{
    public static IServiceCollection AddCore(this IServiceCollection services, params Assembly[] assembliesToScan)
    {
        var scanAssemblies = assembliesToScan.Any() ? assembliesToScan : new[] { Assembly.GetCallingAssembly() };
        services.AddTransient<IAggregatesDomainEventsRequestStore, AggregatesDomainEventsStore>();
        services.AddTransient<IAggregatesDomainEventsRequestStore, AggregatesDomainEventsStore>();
        services.AddTransient<IDomainEventPublisher, DomainEventPublisher>();
        services.AddTransient<IDomainEventsAccessor, DomainEventAccessor>();

        services.AddScoped<ISieveProcessor, ApplicationSieveProcessor>();
        services.ScanAndRegisterDbExecutors(scanAssemblies);

        var policy = Policy.Handle<System.Exception>().RetryAsync(2);
        services.AddSingleton<AsyncPolicy>(policy);

        return services;
    }
}
