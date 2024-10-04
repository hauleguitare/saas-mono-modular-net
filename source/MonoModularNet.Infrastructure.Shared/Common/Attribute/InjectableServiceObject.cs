using Microsoft.Extensions.DependencyInjection;

namespace MonoModularNet.Infrastructure.Shared.Common.Attribute;

public struct InjectableServiceObject
{
    public Type? Interface { get; set; }
    public Type? Implementation { get; set; }
    public ServiceLifetime? Lifetime { get; set; }
        
    public InjectableServiceObject(
            
    ) {}
}