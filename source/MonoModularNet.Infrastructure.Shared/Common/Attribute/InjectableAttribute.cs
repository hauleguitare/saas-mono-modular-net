using Microsoft.Extensions.DependencyInjection;

namespace MonoModularNet.Infrastructure.Shared.Common.Attribute;

[AttributeUsage(AttributeTargets.Class)]
public class InjectableAttribute: System.Attribute
{
    public Type InterfaceType { get; set; } = null!;
    public ServiceLifetime Lifetime { get; set; } = ServiceLifetime.Transient;
}
