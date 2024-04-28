using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Ytsoob.Shared.EF;

namespace Ytsoob.Shared.Data;

public class YtsoobDbContext : EfDbContextBase
{
    public const string DefaultSchema = "ytsoob";

    public YtsoobDbContext(DbContextOptions<YtsoobDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }
}
