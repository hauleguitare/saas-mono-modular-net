namespace MonoModularNet.Infrastructure.Cache.Abstraction;

public interface ICacheService
{
    T? Get<T>(string key);
    Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default);
    bool Set(string key, object value, TimeSpan expirationTimeSpan);
    Task<bool> SetAsync(string key, object value, TimeSpan expirationTimeSpan, CancellationToken cancellationToken = default);
    bool Set(string key, string value, TimeSpan expirationTimeSpan);
    Task<bool> SetAsync(string key, string value, TimeSpan expirationTimeSpan, CancellationToken cancellationToken = default);
    void Remove(string key);
}