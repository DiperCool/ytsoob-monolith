using CorrelationId;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Serilog;
using Ytsoob.Shared.Web.Extensions;
using Ytsoob.Shared.Web.Minimal.Extensions;
using Ytsoob.Shared.Web.ProblemDetail.Middlewares.CaptureExceptionMiddleware;

namespace Ytsoob.Shared.Extensions.WebApplicationExtensions;

public static partial class WebApplicationExtensions
{
    public static Task UseInfrastructure(this WebApplication app)
    {
        app.UseCustomCors();
        // https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/security
        app.UseAuthentication();
        app.UseAuthorization();

        // https://github.com/stevejgordon/CorrelationId
        app.UseCorrelationId();

        return Task.CompletedTask;
    }
}
