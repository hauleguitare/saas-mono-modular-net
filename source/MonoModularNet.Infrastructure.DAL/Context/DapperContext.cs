using System.Data;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace MonoModularNet.Infrastructure.DAL.Context;

public interface IDapperContext
{
    IReadOnlyList<T> Query<T>(string sql, object param = null, IDbTransaction transaction = null);
    T QueryFirst<T>(string sql, object param = null, IDbTransaction transaction = null);
    T? QueryFirstOrDefault<T>(string sql, object param = null, IDbTransaction transaction = null);
    T? QuerySingleOrDefault<T>(string sql, object param = null, IDbTransaction transaction = null);
    Task<IReadOnlyList<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null,
        CancellationToken cancellationToken = default);

    Task<T> QueryFirstAsync<T>(string sql, object param = null, IDbTransaction transaction = null,
        CancellationToken cancellationToken = default);

    Task<T?> QueryFirstOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null,
        CancellationToken cancellationToken = default);

    Task<T?> QuerySingleOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null,
        CancellationToken cancellationToken = default);
    Task<T> QuerySingleAsync<T>(string sql, object param = null, IDbTransaction transaction = null,
        CancellationToken cancellationToken = default);
}

public class DapperContext : IDapperContext
{
    private readonly string _connectionString;

    public DapperContext(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        ArgumentException.ThrowIfNullOrEmpty(connectionString);
        _connectionString = connectionString;
    }

    public IDbConnection CreateConnection() => new NpgsqlConnection(_connectionString);
    
    private bool _disposed = false;
    protected virtual void Dispose(bool disposing)
    {
        if (!this._disposed)
        {
            if (disposing)
            {
                //TODO:
                // Implement context dispose here
            }
        }
        this._disposed = true;
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public IReadOnlyList<T> Query<T>(string sql, object param = null, IDbTransaction transaction = null)
    {
        using (var connection = CreateConnection())
        {
            return connection.Query<T>(sql, param, transaction).AsList();
        }
    }

    public T QueryFirst<T>(string sql, object param = null, IDbTransaction transaction = null)
    {
        using (var connection = CreateConnection())
        {
            return connection.QueryFirst<T>(sql, param, transaction);
        }
    }

    public T? QueryFirstOrDefault<T>(string sql, object param = null, IDbTransaction transaction = null)
    {
        using (var connection = CreateConnection())
        {
            return connection.QueryFirstOrDefault<T>(sql, param, transaction);
        }
    }

    public T? QuerySingleOrDefault<T>(string sql, object param = null, IDbTransaction transaction = null)
    {
        using (var connection = CreateConnection())
        {
            return connection.QuerySingleOrDefault<T>(sql, param, transaction);
        }
    }

    public async Task<IReadOnlyList<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null,
        CancellationToken cancellationToken = default)
    {
        using (var connection = CreateConnection())
        {
            return (await connection.QueryAsync<T>(sql, param, transaction)).AsList();
        }
    }

    public async Task<T> QueryFirstAsync<T>(string sql, object param = null, IDbTransaction transaction = null,
        CancellationToken cancellationToken = default)
    {
        using (var connection = CreateConnection())
        {
            return await connection.QueryFirstAsync<T>(sql, param, transaction);
        }
    }

    public async Task<T?> QueryFirstOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null,
        CancellationToken cancellationToken = default)
    {
        using (var connection = CreateConnection())
        {
            return await connection.QueryFirstOrDefaultAsync<T>(sql, param, transaction);
        }
    }
    
    public async Task<T?> QuerySingleOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null,
        CancellationToken cancellationToken = default)
    {
        using (var connection = CreateConnection())
        {
            return await connection.QuerySingleOrDefaultAsync<T>(sql, param, transaction);
        }
    }

    public async Task<T> QuerySingleAsync<T>(string sql, object param = null, IDbTransaction transaction = null,
        CancellationToken cancellationToken = default)
    {
        using (var connection = CreateConnection())
        {
            return await connection.QuerySingleAsync<T>(sql, param, transaction);
        }
    }
}
