using System.Reflection;
using Microsoft.AspNetCore.Http;
using Scrutor;
using Ytsoob.Shared.Abstractions.Web;
using Ytsoob.Shared.Core.Extensions.ServiceCollectionsExtensions;
using Ytsoob.Shared.Core.Reflection;

namespace Ytsoob.Shared.Web.ProblemDetail;

// https://www.strathweb.com/2022/08/problem-details-responses-everywhere-with-asp-net-core-and-net-7/
public static class RegistrationExtensions
{
    public static IServiceCollection AddCustomProblemDetails(
        this IServiceCollection services,
        Action<ProblemDetailsOptions>? configure = null,
        params Assembly[] scanAssemblies
    )
    {
        var assemblies = scanAssemblies.Any() ? scanAssemblies : AppDomain.CurrentDomain.GetAssemblies();

        services.AddProblemDetails(configure);
        services.ReplaceSingleton<IProblemDetailsService, ProblemDetailsService>();
        // services.AddSingleton<IProblemDetailsWriter, ProblemDetailsWriter>();

        RegisterAllMappers(services, assemblies);

        return services;
    }

    private static void RegisterAllMappers(IServiceCollection services, Assembly[] scanAssemblies)
    {
        services.Scan(
            scan =>
                scan.FromAssemblies(scanAssemblies)
                    .AddClasses(classes => classes.AssignableTo(typeof(IProblemDetailMapper)), false)
                    .UsingRegistrationStrategy(RegistrationStrategy.Append)
                    .As<IProblemDetailMapper>()
                    .WithLifetime(ServiceLifetime.Singleton)
        );
    }
}