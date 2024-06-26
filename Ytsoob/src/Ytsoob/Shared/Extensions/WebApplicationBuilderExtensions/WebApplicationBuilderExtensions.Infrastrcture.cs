using CorrelationId.DependencyInjection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Ytsoob.Shared.Abstractions.Core;
using Ytsoob.Shared.Abstractions.Ef.Repository;
using Ytsoob.Shared.Auth0;
using Ytsoob.Shared.Cache;
using Ytsoob.Shared.Cache.Behaviours;
using Ytsoob.Shared.Core.Extensions.ServiceCollectionsExtensions;
using Ytsoob.Shared.Data;
using Ytsoob.Shared.EF;
using Ytsoob.Shared.Logging;
using Ytsoob.Shared.Securiry;
using Ytsoob.Shared.Swagger;
using Ytsoob.Shared.Validation;
using Ytsoob.Shared.Validation.Extensions;
using Ytsoob.Shared.Web.Extensions;
using Ytsoob.Shared.Web.Extensions.WebApplicationBuilderExtensions;
using Ytsoob.Shared.Web.Minimal.Extensions;

namespace Ytsoob.Shared.Extensions.WebApplicationBuilderExtensions;

public static partial class WebApplicationBuilderExtensions
{
    public static WebApplicationBuilder AddInfrastructures(this WebApplicationBuilder builder)
    {
        SnowFlakIdGenerator.Configure(1);
        builder.Services.AddCore();

        builder.AddCustomEasyCaching();
        builder.AddAuth0();
        // https://github.com/stevejgordon/CorrelationId
        builder.Services.AddDefaultCorrelationId();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.AddCustomSwagger();
        builder.Services.AddScoped<ICurrentUserService, CurrentUserService>();
        builder.AddCustomVersioning();
        builder.AddMinimalEndpoints();
        builder.AddCustomCors();

        // https://github.com/tonerdo/dotnet-env
        DotNetEnv.Env.TraversePath().Load();

        builder.AddCompression();

        builder.Services.AddHttpContextAccessor();

        builder.Services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(YtsoobMetadata).Assembly));
        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(StreamLoggingBehavior<,>));
        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(StreamRequestValidationBehavior<,>));
        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CachingBehavior<,>));
        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(StreamCachingBehavior<,>));
        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(InvalidateCachingBehavior<,>));
        builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(EfTxBehavior<,>));

        builder.Services.AddAutoMapper(typeof(YtsoobMetadata).Assembly);

        builder.Services.AddCustomValidators(typeof(YtsoobMetadata).Assembly);

        builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        builder.Services.AddScoped(typeof(IReadRepository<>), typeof(GenericRepository<>));

        return builder;
    }
}
