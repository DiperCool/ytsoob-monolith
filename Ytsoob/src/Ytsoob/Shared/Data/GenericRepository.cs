using Ytsoob.Shared.Core.Ef;

namespace Ytsoob.Shared.Data;

public class GenericRepository<T> : EfRepository<T, YtsoobDbContext>
    where T : class
{
    public GenericRepository(YtsoobDbContext dbContext)
        : base(dbContext)
    {
    }
}
