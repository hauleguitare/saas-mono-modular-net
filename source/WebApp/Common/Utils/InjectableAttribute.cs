namespace WebApp.Common.Utils;


[AttributeUsage(AttributeTargets.Interface)]
public class InjectableAttribute: Attribute
{
    public ServiceLifetime Lifetime { get; set; } = ServiceLifetime.Transient;
}
