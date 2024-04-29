using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Ytsoob.Shared.Extensions.WebApplicationBuilderExtensions;
using Ytsoob.Shared.Extensions.WebApplicationExtensions;
using Ytsoob.Shared.Web.Minimal.Extensions;

namespace Ytsoob.Shared;

public static class YtsoobConfigurations
{
    public const string PrefixUri = "api/v{version:apiVersion}";

    public static WebApplicationBuilder AddYtsoobServices(this WebApplicationBuilder builder)
    {
        // Shared
        // Infrastructure
        builder.AddInfrastructures();

        // Shared
        // Catalogs Configurations
        builder.AddStorage();

        // Modules

        return builder;
    }

    public static async Task<WebApplication> UseYtsoob(this WebApplication app)
    {
        // Shared
        await app.UseInfrastructure();

        // Modules

        return app;
    }

    public static IEndpointRouteBuilder MapYtsoobEndpoints(this IEndpointRouteBuilder endpoints)
    {
        // Shared
        endpoints.MapGet("/", () => "Ytsoob  Api.").ExcludeFromDescription();
        endpoints.MapMinimalEndpoints();

        // Modules

        return endpoints;
    }
}
