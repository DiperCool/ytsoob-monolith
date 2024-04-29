using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Ytsoob.Profiles.Models;
using Ytsoob.Shared.EF;
using Ytsoob.Ytsoobers.Models;

namespace Ytsoob.Shared.Data;

public class YtsoobDbContext : EfDbContextBase
{
    public const string DefaultSchema = "ytsoob";
    public DbSet<Ytsoober> Ytsoobers => Set<Ytsoober>();
    public DbSet<Profile> Profiles => Set<Profile>();

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
