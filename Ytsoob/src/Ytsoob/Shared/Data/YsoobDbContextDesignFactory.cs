using Ytsoob.Shared.EF;

namespace Ytsoob.Shared.Data;

public class YtsoobDbContextDesignFactory : DbContextDesignFactoryBase<YtsoobDbContext>
{
    public YtsoobDbContextDesignFactory()
        : base($"{nameof(PostgresOptions)}:{nameof(PostgresOptions.ConnectionString)}")
    {
    }
}
