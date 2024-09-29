using System.Data;
using Dapper;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Common.Attribute;

namespace MonoModularNet.Infrastructure.DAL.Repository;

public interface IDapperRepository: IRepository
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

[Injectable(InterfaceType = typeof(IDapperRepository), Lifetime = ServiceLifetime.Scoped)]
public class DapperRepository : IDapperRepository
{
    private readonly IDbConnection _connection;

    public DapperRepository()
    {
    }
    
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
        _connection.Dispose();
        GC.SuppressFinalize(this);
    }

    public IReadOnlyList<T> Query<T>(string sql, object param = null, IDbTransaction transaction = null)
    {
        return _connection.Query<T>(sql, param, transaction).AsList();
    }

    public T QueryFirst<T>(string sql, object param = null, IDbTransaction transaction = null)
    {
        return _connection.QueryFirst<T>(sql, param, transaction);
    }

    public T? QueryFirstOrDefault<T>(string sql, object param = null, IDbTransaction transaction = null)
    {
        return _connection.QueryFirstOrDefault<T>(sql, param, transaction);
    }

    public T? QuerySingleOrDefault<T>(string sql, object param = null, IDbTransaction transaction = null)
    {
        return _connection.QuerySingleOrDefault<T>(sql, param, transaction);
    }

    public async Task<IReadOnlyList<T>> QueryAsync<T>(string sql, object param = null, IDbTransaction transaction = null,
        CancellationToken cancellationToken = default)
    {
        return (await _connection.QueryAsync<T>(sql, param, transaction)).AsList();
    }

    public Task<T> QueryFirstAsync<T>(string sql, object param = null, IDbTransaction transaction = null,
        CancellationToken cancellationToken = default)
    {
        return _connection.QueryFirstAsync<T>(sql, param, transaction);
    }

    public Task<T?> QueryFirstOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null,
        CancellationToken cancellationToken = default)
    {
        return _connection.QueryFirstOrDefaultAsync<T>(sql, param, transaction);
    }
    
    public Task<T?> QuerySingleOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null,
        CancellationToken cancellationToken = default)
    {
        return _connection.QuerySingleOrDefaultAsync<T>(sql, param, transaction);
    }

    public Task<T> QuerySingleAsync<T>(string sql, object param = null, IDbTransaction transaction = null,
        CancellationToken cancellationToken = default)
    {
        return _connection.QuerySingleAsync<T>(sql, param, transaction);
    }
}
