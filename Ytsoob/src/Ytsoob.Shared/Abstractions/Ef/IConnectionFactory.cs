using System.Data.Common;

namespace Ytsoob.Shared.Abstractions.Ef;

public interface IConnectionFactory : IDisposable
{
    Task<DbConnection> GetOrCreateConnectionAsync();
}
