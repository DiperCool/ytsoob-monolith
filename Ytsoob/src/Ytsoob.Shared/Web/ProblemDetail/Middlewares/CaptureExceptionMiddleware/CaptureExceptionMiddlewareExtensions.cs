using Microsoft.AspNetCore.Builder;

namespace Ytsoob.Shared.Web.ProblemDetail.Middlewares.CaptureExceptionMiddleware;

//https://github.com/dotnet/aspnetcore/pull/47760
public static class CaptureExceptionMiddlewareExtensions
{
    public static IApplicationBuilder UseCaptureException(this IApplicationBuilder app)
    {
        if (app == null)
        {
            throw new ArgumentNullException(nameof(app));
        }

        app.Properties["analysis.NextMiddlewareName"] =
            "Ytsoob.Shared.Web.Middlewares.CaptureExceptionMiddleware";
        return app.UseMiddleware<CaptureExceptionMiddlewareImp>();
    }
}
