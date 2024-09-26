namespace WebApp.Common.Utils;

[AttributeUsage(AttributeTargets.Class)]
public class InjectableAttribute: Attribute
{
    public Type InterfaceType { get; set; } = null!;
    public ServiceLifetime Lifetime { get; set; } = ServiceLifetime.Transient;
}
