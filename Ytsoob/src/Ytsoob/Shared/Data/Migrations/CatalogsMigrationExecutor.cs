using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Ytsoob.Shared.Abstractions.Ef;

namespace Ytsoob.Shared.Data.Migrations;

public class YtsoobMigrationExecutor : IMigrationExecutor
{
    private readonly YtsoobDbContext _ytsoobContext;
    private readonly ILogger<YtsoobMigrationExecutor> _logger;

    public YtsoobMigrationExecutor(YtsoobDbContext ytsoobContext, ILogger<YtsoobMigrationExecutor> logger)
    {
        _ytsoobContext = ytsoobContext;
        _logger = logger;
    }

    public async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Migration worker started");

        _logger.LogInformation("Updating ytsoob database...");

        await _ytsoobContext.Database.MigrateAsync(cancellationToken: cancellationToken);

        _logger.LogInformation("Ytsoob database Updated");
    }
}
