using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Ytsoob.Shared.Abstractions.Core.Domain.Events;
using Ytsoob.Shared.Abstractions.Ef;
using Ytsoob.Shared.Data;
using Ytsoob.Shared.Data.Migrations;
using Ytsoob.Shared.EF;
using Ytsoob.Shared.EF.Extensions;
using Ytsoob.Shared.Workers;

namespace Ytsoob.Shared.Extensions.WebApplicationBuilderExtensions;

public static partial class WebApplicationBuilderExtensions
{
    public static void AddStorage(this WebApplicationBuilder builder)
    {
        if (builder.Configuration.GetValue<bool>($"{nameof(PostgresOptions)}:{nameof(PostgresOptions.UseInMemory)}"))
        {
            builder.Services.AddDbContext<YtsoobDbContext>(options => options.UseInMemoryDatabase("Ytsoob"));

            builder.Services.AddScoped<IDbFacadeResolver>(provider => provider.GetService<YtsoobDbContext>()!);
            builder.Services.AddScoped<IDomainEventContext>(provider => provider.GetService<YtsoobDbContext>()!);
        }
        else
        {
            builder.Services.AddPostgresDbContext<YtsoobDbContext>();

            builder.Services.AddHostedService<MigrationWorker>();
            builder.Services.AddHostedService<SeedWorker>();

            // add migration and seeders dependencies
            builder.Services.AddScoped<IMigrationExecutor, YtsoobMigrationExecutor>();
            //services.AddScoped<IDataSeeder, Seeder>();
        }
    }
}
