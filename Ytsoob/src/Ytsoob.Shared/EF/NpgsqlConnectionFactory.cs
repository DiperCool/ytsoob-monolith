using System.Data;
using System.Data.Common;
using Npgsql;
using Ytsoob.Shared.Abstractions.Ef;
using Ytsoob.Shared.Core.Extensions;

namespace Ytsoob.Shared.EF;

public class NpgsqlConnectionFactory : IConnectionFactory
{
    private readonly string _connectionString;
    private DbConnection? _connection;

    public NpgsqlConnectionFactory(string? connectionString)
    {
        connectionString.NotBeNullOrWhiteSpace();
        _connectionString = connectionString;
    }

    public async Task<DbConnection> GetOrCreateConnectionAsync()
    {
        if (_connection is null || _connection.State != ConnectionState.Open)
        {
            _connection = new NpgsqlConnection(_connectionString);
            await _connection.OpenAsync();
        }

        return _connection;
    }

    public void Dispose()
    {
        if (_connection is { State: ConnectionState.Open })
            _connection.Dispose();
        GC.SuppressFinalize(this);
    }
}
