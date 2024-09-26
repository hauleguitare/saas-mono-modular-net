using Microsoft.Extensions.DependencyInjection;

namespace SharedKernel.Common.Struct;

public struct InjectableServiceObject
{
    public Type? Interface { get; set; }
    public Type? Implementation { get; set; }
    public ServiceLifetime? Lifetime { get; set; }
        
    public InjectableServiceObject(
            
    ) {}
}