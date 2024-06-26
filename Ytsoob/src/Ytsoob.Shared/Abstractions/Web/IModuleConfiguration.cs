using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Ytsoob.Shared.Abstractions.Web;

public interface IModuleConfiguration
{
    WebApplicationBuilder AddModuleServices(WebApplicationBuilder builder);

    Task<WebApplication> ConfigureModule(WebApplication app);

    IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints);
}
