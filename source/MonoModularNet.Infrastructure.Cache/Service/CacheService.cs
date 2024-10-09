using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using MonoModularNet.Infrastructure.Cache.Abstraction;
using MonoModularNet.Infrastructure.Shared.Common.Attribute;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace MonoModularNet.Infrastructure.Cache.Service;




[Injectable(InterfaceType = typeof(ICacheService), Lifetime = ServiceLifetime.Scoped)]
public class CacheService: ICacheService
{
    private readonly IDistributedCache _distributedCache;

    public CacheService(IDistributedCache distributedCache)
    {
        _distributedCache = distributedCache;
    }

    public T? Get<T>(string key)
    {
        var rawData = _distributedCache.GetString(key);

        return string.IsNullOrEmpty(rawData) ? default : JsonConvert.DeserializeObject<T>(rawData,new JsonSerializerSettings()
        {
            ContractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            }
        });
    }

    public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default)
    {
        var rawData = await _distributedCache.GetStringAsync(key, cancellationToken);

        var result = string.IsNullOrEmpty(rawData) ? default : JsonConvert.DeserializeObject<T>(rawData, new JsonSerializerSettings()
        {
            ContractResolver = new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            }
        });

        return result;
    }


    public bool Set(string key, object value, TimeSpan expirationTimeSpan)
    {
        try
        {
            var rawData = JsonConvert.SerializeObject(value, new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
            _distributedCache.SetString(key, rawData, new DistributedCacheEntryOptions().SetSlidingExpiration(expirationTimeSpan));
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> SetAsync(string key, object value, TimeSpan expirationTimeSpan, CancellationToken cancellationToken = default)
    {
        try
        {
            var rawData = JsonConvert.SerializeObject(value, new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
            await _distributedCache.SetStringAsync(key, rawData, new DistributedCacheEntryOptions().SetSlidingExpiration(expirationTimeSpan), cancellationToken);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool Set(string key, string value, TimeSpan expirationTimeSpan)
    {
        try
        {
            _distributedCache.SetString(key, value, new DistributedCacheEntryOptions().SetSlidingExpiration(expirationTimeSpan));
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<bool> SetAsync(string key, string value, TimeSpan expirationTimeSpan, CancellationToken cancellationToken = default)
    {
        try
        {
            await _distributedCache.SetStringAsync(key, value, new DistributedCacheEntryOptions().SetSlidingExpiration(expirationTimeSpan), cancellationToken);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }


    public void Remove(string key)
    {
        _distributedCache.Remove(key);
    }
}
